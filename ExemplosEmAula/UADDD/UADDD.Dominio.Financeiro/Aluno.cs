using System;
using System.Collections.Generic;
using System.Text;

namespace UADDD.Dominio.Financeiro
{
    public class Aluno : Entidade.Aluno
    {

        public bool PagamentoUnico { get; set; }
        public MeioPagamento MeioPagamento { get; set; }
        public DateTime UltimoPagamento { get; set; }

        public bool Adimplencia()
        {
            return PagamentoUnico || 
                   AlunoAtivo() && (DateTime.Now - UltimoPagamento).Days <= 45;
        }
    }
}
