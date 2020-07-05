using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeDataBaseNetCore.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Descricao { get; set; }

        public List<Filme> Filme { get; set; }
    }
}
