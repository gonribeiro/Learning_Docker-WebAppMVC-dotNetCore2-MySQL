using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace almoxarifado.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string CodigoBarras { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}