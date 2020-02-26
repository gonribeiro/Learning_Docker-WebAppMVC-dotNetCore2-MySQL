using System;

namespace ClienteDDD.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataNasc { get; set; }
    }
}
