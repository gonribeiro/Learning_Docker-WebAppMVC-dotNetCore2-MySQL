using System;
using System.Collections.Generic;
using System.Text;

namespace BluBank
{
    public class Cliente : Conta
    {
        private string nome;
        private int numero;
        private int senha;

        public string Nome { get => nome; private set => nome = value; }
        public int Numero { get => numero; private set => numero = value; }
        public int Senha { get => senha; private set => senha = value; }

        public Cliente()
        {
            Nome = "Fulano";
            Numero = 1234;
            Senha = 1234;
        }
    }
}
