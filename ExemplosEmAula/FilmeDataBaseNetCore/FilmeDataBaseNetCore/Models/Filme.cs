using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeDataBaseNetCore.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título BR")] 
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Título Original")]
        public string TituloOriginal { get; set; }

        [Required]
        [Display(Name = "Lançamento")]
        public DateTime Ano { get; set; }

        [Required]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
