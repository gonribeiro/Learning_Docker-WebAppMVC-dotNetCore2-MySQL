using System;
using System.Collections.Generic;
using System.Text;

namespace EstacoesDaCidade.Dominio.Entidades
{
    public class EstacaoRecarga
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
