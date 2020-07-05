using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BokuNoHeroAcademia.Models
{
    public class Professor : Pessoa
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data da Contratação")]
        public DateTime DataContratacao { get; set; }

        public ICollection<CursoAtribuido> CursosAtribuidos { get; set; }
    }
}