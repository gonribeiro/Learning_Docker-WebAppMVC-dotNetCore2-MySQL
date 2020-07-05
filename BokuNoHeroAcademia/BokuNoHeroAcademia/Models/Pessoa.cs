using System.ComponentModel.DataAnnotations;

namespace BokuNoHeroAcademia.Models
{
    public abstract class Pessoa
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome de Heroi")]
        public string NomeHeroi { get; set; }
    }
}