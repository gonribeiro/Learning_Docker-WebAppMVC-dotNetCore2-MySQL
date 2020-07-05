using System;
using System.Collections.Generic;

namespace UADDD.Dominio.Biblioteca
{
    public class Aluno : Entidade.Aluno
    {
        ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
