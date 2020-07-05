using System.Collections.Generic;
using UADDD.Dominio.Entidade;
using UADDD.Dominio.Interfaces.Servicos;
using UADDD.Dominio.Interfaces.Repositorios;

namespace UADDD.Dominio.Servicos
{
    public class AlunoServicoDominio : BaseServicoDominio<Aluno>, IAlunoServicoDominio
    {
        public readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoServicoDominio(IAlunoRepositorio alunoRepositorio)
            : base(alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public Aluno DetalharPorNome(string busca)
        {
            return _alunoRepositorio.DetalharPorNome(busca);
        }

        public IEnumerable<Aluno> ListarAlunosAtivos()
        {
            return _alunoRepositorio.ListarAlunosAtivos();
        }
    }
}
