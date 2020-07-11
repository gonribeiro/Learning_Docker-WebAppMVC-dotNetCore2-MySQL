using System;
using System.ComponentModel.DataAnnotations;

namespace BokuNoHeroAcademia.Models.AcademiaViewModels
{
    public class InscricaoAluno
    {
        /*[DataType(DataType.Date)]
        public DateTime? Inscricao { get; set; }

        public int EstudanteCount { get; set; }*/

        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public bool Inscrito { get; set; }
    }
}