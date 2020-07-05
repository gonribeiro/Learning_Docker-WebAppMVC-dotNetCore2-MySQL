using System;
using System.Collections.Generic;
using System.Text;
using UADDD.Dominio.Entidade;

namespace UADDD.Dominio.Interfaces.Servicos
{
    public interface IAlunoServicoDominio : IBaseServicoDominio<Aluno>
    {
        Aluno DetalharPorNome(string busca);
        IEnumerable<Aluno> ListarAlunosAtivos();
    }
}
