using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeDataBaseNetCore.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        public int CalcularIdade()
        {
            return new DateTime(DateTime.Now.Subtract(Nascimento).Ticks).Year - 1;
        }
    }
}
