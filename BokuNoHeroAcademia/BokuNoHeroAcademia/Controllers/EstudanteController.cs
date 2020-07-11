using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BokuNoHeroAcademia.Data;
using BokuNoHeroAcademia.Models;
using System.Collections.Generic;
using BokuNoHeroAcademia.Models.AcademiaViewModels;

namespace BokuNoHeroAcademia.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly AcademiaContext _context;

        public EstudanteController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: Estudante
        public async Task<IActionResult> Index(int? id, int? CursoID)
        {
            var viewModel = new EstudanteCurso();
            viewModel.Estudantes = await _context.Estudante
                  .Include(i => i.Inscricoes)
                    .ThenInclude(i => i.Curso)
                  .OrderBy(i => i.NomeHeroi)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["EstudanteID"] = id.Value;
                Estudante estudante = viewModel.Estudantes.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Cursos = estudante.Inscricoes.Select(s => s.Curso);
            }

            return View(viewModel);
        }

        // GET: Estudante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataMatricula,ID,Nome,NomeHeroi")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudante);
        }

        // GET: Estudante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Select2 a implementar
            /*ViewData["Cursos"] = new SelectList(_context.Curso, "CursoID", "Titulo");
            var estudante = await _context.Estudante.FindAsync(id);*/

            var estudante = await _context.Estudante
                .Include(i => i.Inscricoes).ThenInclude(i => i.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (estudante == null)
            {
                return NotFound();
            }

            PopularDadosDeInscricoes(estudante);
            return View(estudante);
        }

        // Carrega os cursos que o professor leciona
        private void PopularDadosDeInscricoes(Estudante estudante)
        {
            var todosCursos = _context.Curso;
            var estudanteCursos = new HashSet<int>(estudante.Inscricoes.Select(c => c.CursoId));
            var viewModel = new List<InscricaoAluno>();
            foreach (var curso in todosCursos)
            {
                viewModel.Add(new InscricaoAluno
                {
                    CursoID = curso.CursoID,
                    Titulo = curso.Titulo,
                    Inscrito = estudanteCursos.Contains(curso.CursoID)
                });
            }
            ViewData["Curso"] = viewModel;
        }

        // POST: Estudante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] Inscricoes)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atualizarEstudante = await _context.Estudante
                .Include(i => i.Inscricoes)
                    .ThenInclude(i => i.Curso)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (await TryUpdateModelAsync<Estudante>(
                atualizarEstudante,
                "",
                i => i.Nome, i => i.NomeHeroi, i => i.DataMatricula))
            {
                AtualizarEstudanteCursos(Inscricoes, atualizarEstudante);
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
            AtualizarEstudanteCursos(Inscricoes, atualizarEstudante);
            PopularDadosDeInscricoes(atualizarEstudante);
            return View(atualizarEstudante);
        }

        // Atualiza os cursos do estudante
        private void AtualizarEstudanteCursos(string[] Inscricoes, Estudante atualizarAluno)
        {
            if (Inscricoes == null)
            {
                atualizarAluno.Inscricoes = new List<Inscricao>();
                return;
            }

            var InscricoesHS = new HashSet<string>(Inscricoes);
            var alunoCursos = new HashSet<int>
                (atualizarAluno.Inscricoes.Select(c => c.Curso.CursoID));
            foreach (var curso in _context.Curso)
            {
                if (InscricoesHS.Contains(curso.CursoID.ToString()))
                {
                    if (!alunoCursos.Contains(curso.CursoID))
                    {
                        atualizarAluno.Inscricoes.Add(new Inscricao { EstudanteId = atualizarAluno.ID, CursoId = curso.CursoID });
                    }
                }
                else
                {
                    if (alunoCursos.Contains(curso.CursoID))
                    {
                        Inscricao RemoveCurso = atualizarAluno.Inscricoes.FirstOrDefault(i => i.CursoId == curso.CursoID);
                        _context.Remove(RemoveCurso);
                    }
                }
            }
        }

        // GET: Estudante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudante
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _context.Estudante.FindAsync(id);
            _context.Estudante.Remove(estudante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudante.Any(e => e.ID == id);
        }
    }
}