using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UADDD.Dominio.Entidade;
using UADDD.Dominio.Interfaces.Repositorios;

namespace UADDD.Infraestrutura.Persistencia.Repositorio
{
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        public UADbContext _contexto;

        public AlunoRepositorio(UADbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Aluno DetalharPorNome(string busca)
        {
            return _contexto.Alunos.FirstOrDefault(a => (a.Nome + " " + a.Sobrenome).Contains(busca));
        }

        public IEnumerable<Aluno> ListarAlunosAtivos()
        {
            return _contexto.Alunos.Where(a => a.AlunoAtivo()).ToList();
        }
    }
}
