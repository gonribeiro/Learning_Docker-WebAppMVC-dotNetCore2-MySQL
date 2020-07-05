using System;
using System.ComponentModel.DataAnnotations;

namespace BokuNoHeroAcademia.Models.AcademiaViewModels
{
    public class InscricaoAluno
    {
        [DataType(DataType.Date)]
        public DateTime? Inscricao { get; set; }

        public int EstudanteCount { get; set; }
    }
}