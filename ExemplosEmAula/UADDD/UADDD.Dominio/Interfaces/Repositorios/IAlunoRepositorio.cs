using System;
using System.Collections.Generic;
using System.Text;
using UADDD.Dominio.Entidade;

namespace UADDD.Dominio.Interfaces.Repositorios
{
    public interface IAlunoRepositorio : IBaseRepositorio<Aluno>
    {
        Aluno DetalharPorNome(string busca);
        IEnumerable<Aluno> ListarAlunosAtivos();
    }
}
