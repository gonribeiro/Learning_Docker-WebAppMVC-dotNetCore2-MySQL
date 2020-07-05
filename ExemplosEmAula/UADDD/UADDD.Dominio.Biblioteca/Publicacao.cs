using System.Collections.Generic;

namespace UADDD.Dominio.Biblioteca
{
    public class Publicacao : BaseEntidade
    {
        public string Titulo { get; set; }
        public int Quantidade { get; set; }

        ICollection<Emprestimo> Emprestimos { get; set; }
    }
}