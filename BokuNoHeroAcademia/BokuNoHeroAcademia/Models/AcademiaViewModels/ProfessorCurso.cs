using BokuNoHeroAcademia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokuNoHeroAcademia.Models.AcademiaViewModels
{
    public class ProfessorCurso
    {
        public IEnumerable<Professor> Professores { get; set; }
        public IEnumerable<Curso> Cursos { get; set; }
        public IEnumerable<Inscricao> Inscricoes { get; set; }
    }
}