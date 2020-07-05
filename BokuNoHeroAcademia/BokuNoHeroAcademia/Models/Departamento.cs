using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BokuNoHeroAcademia.Models
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        public int? ProfessorID { get; set; }

        public Professor Coordenador { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}