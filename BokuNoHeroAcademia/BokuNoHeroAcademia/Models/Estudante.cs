using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BokuNoHeroAcademia.Models
{
    public class Estudante : Pessoa
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data da Matricula")]
        public DateTime DataMatricula { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}
