using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BokuNoHeroAcademia.Data;
using BokuNoHeroAcademia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudante.ToListAsync());
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


            ViewData["Cursos"] = new SelectList(_context.Curso, "CursoID", "Titulo");
            var estudante = await _context.Estudante.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataMatricula,ID,Nome,NomeHeroi")] Estudante estudante, int[] Inscricoes)
        {
            if (id != estudante.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var inscricoes = Inscricoes;
                    _context.Update(estudante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudanteExists(estudante.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudante);
        }

        // Atualiza os cursos do professor
        private void AtualizarEstudanteCursos(string[] CursosSelecionados, Estudante atualizarAluno)
        {
            if (CursosSelecionados == null)
            {
                atualizarAluno.Inscricoes = new List<Inscricao>();
                return;
            }

            var CursosSelecionadosHS = new HashSet<string>(CursosSelecionados);
            var alunoCursos = new HashSet<int>
                (atualizarAluno.Inscricoes.Select(c => c.Curso.CursoID));
            foreach (var curso in _context.Curso)
            {
                if (CursosSelecionadosHS.Contains(curso.CursoID.ToString()))
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