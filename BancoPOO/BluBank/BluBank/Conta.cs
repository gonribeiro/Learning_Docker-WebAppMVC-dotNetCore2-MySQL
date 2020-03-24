using System;
using System.Collections.Generic;
using System.Text;

namespace BluBank
{
    public abstract class Conta
    {
        private decimal saldo;
        public decimal Saldo { get => saldo; private set => saldo = value; }

        public virtual void Sacar(decimal valor)
        {
            // Permite saque de valor for positivo e se saldo for maior que desejado retirar
            if (valor > 0 && Saldo > valor)
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado!");
            }
            else
            {
                Console.WriteLine("Você não pode sacar um valor negativo ou maior que o seu saldo atual");
            }
        }

        public void Depositar(decimal valor)
        {
            // Deposita se valor for positivo
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine("Depositado com sucesso!");
            } 
            else
            {
                Console.WriteLine("Você não pode depositar um valor negativo");
            }
        }
    }
}
