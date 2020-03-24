using System;
using System.Collections.Generic;
using System.Text;

namespace BluBank
{
    public class ContaPoupanca : Conta
    {
        private decimal taxaMovimento; // Taxa de movimentação

        public decimal TaxaMovimento { get => taxaMovimento; set => taxaMovimento = value; }

        public ContaPoupanca()
        {
            this.TaxaMovimento = 0.1m; // 10%
        }

        // Saque com taxa de movimentação
        public override void Sacar(decimal valor)
        {
            base.Sacar(valor + (this.taxaMovimento * valor));
        }
    }
}
