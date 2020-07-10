using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BokuNoHeroAcademia.Data;
using BokuNoHeroAcademia.Models;
using BokuNoHeroAcademia.Models.AcademiaViewModels;

namespace BokuNoHeroAcademia.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly AcademiaContext _context;

        public ProfessorController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(int? id, int? CursoID)
        {
            var viewModel = new ProfessorCurso();
            viewModel.Professores = await _context.Professor
                  .Include(i => i.CursosAtribuidos)
                    .ThenInclude(i => i.Curso)
                        .ThenInclude(i => i.Departamento)
                  .OrderBy(i => i.NomeHeroi)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["ProfessorID"] = id.Value;
                Professor professor = viewModel.Professores.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Cursos = professor.CursosAtribuidos.Select(s => s.Curso);
            }

            return View(viewModel);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataContratacao,ID,Nome,NomeHeroi")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .Include(i => i.CursosAtribuidos).ThenInclude(i => i.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (professor == null)
            {
                return NotFound();
            }

            PopularDadosCursoAtribuido(professor);
            return View(professor);
        }

        // Carrega os cursos que o professor leciona
        private void PopularDadosCursoAtribuido(Professor professor)
        {
            var todosCursos = _context.Curso;
            var professorCursos = new HashSet<int>(professor.CursosAtribuidos.Select(c => c.CursoID));
            var viewModel = new List<DadosCursoAtribuido>();
            foreach (var curso in todosCursos)
            {
                viewModel.Add(new DadosCursoAtribuido
                {
                    CursoID = curso.CursoID,
                    Titulo = curso.Titulo,
                    Atribuido = professorCursos.Contains(curso.CursoID)
                });
            }
            ViewData["Curso"] = viewModel;
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] CursosSelecionados)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atualizarProfessor = await _context.Professor
                .Include(i => i.CursosAtribuidos)
                    .ThenInclude(i => i.Curso)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (await TryUpdateModelAsync<Professor>(
                atualizarProfessor,
                "",
                i => i.Nome, i => i.NomeHeroi, i => i.DataContratacao))
            {
                AtualizarProfessorCursos(CursosSelecionados, atualizarProfessor);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Impossível atualizar. " +
                        "Tente novamente, caso erro persista " +
                        "entre em contato com o administrador.");
                }
                return RedirectToAction(nameof(Index));
            }
            AtualizarProfessorCursos(CursosSelecionados, atualizarProfessor);
            PopularDadosCursoAtribuido(atualizarProfessor);
            return View(atualizarProfessor);
        }

        // Atualiza os cursos do professor
        private void AtualizarProfessorCursos(string[] CursosSelecionados, Professor atualizarProfessor)
        {
            if (CursosSelecionados == null)
            {
                atualizarProfessor.CursosAtribuidos = new List<CursoAtribuido>();
                return;
            }

            var CursosSelecionadosHS = new HashSet<string>(CursosSelecionados);
            var professorCursos = new HashSet<int>
                (atualizarProfessor.CursosAtribuidos.Select(c => c.Curso.CursoID));
            foreach (var curso in _context.Curso)
            {
                if (CursosSelecionadosHS.Contains(curso.CursoID.ToString()))
                {
                    if (!professorCursos.Contains(curso.CursoID))
                    {
                        atualizarProfessor.CursosAtribuidos.Add(new CursoAtribuido { ProfessorID = atualizarProfessor.ID, CursoID = curso.CursoID });
                    }
                }
                else
                {
                    if (professorCursos.Contains(curso.CursoID))
                    {
                        CursoAtribuido RemoveCurso = atualizarProfessor.CursosAtribuidos.FirstOrDefault(i => i.CursoID == curso.CursoID);
                        _context.Remove(RemoveCurso);
                    }
                }
            }
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.ID == id);
        }
    }
}
