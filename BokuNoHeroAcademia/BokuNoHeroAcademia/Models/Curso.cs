using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokuNoHeroAcademia.Models
{
    public class Curso
    {
        // O atributo DatabaseGenerated permite que o aplicativo especifique a chave primária em vez de fazer com que ela seja gerada pelo banco de dados.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numero")]
        public int CursoID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Titulo { get; set; }

        [Range(0, 5)]
        public int Creditos { get; set; }

        public int DepartamentoID { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Inscricao> Inscricoes { get; set; }
        public ICollection<CursoAtribuido> CursosAtribuidos { get; set; }
    }
}