using System;
using System.Collections.Generic;
using System.Text;
using UADDD.Aplicacao.DTO;
using UADDD.Aplicacao.Interfaces;
using UADDD.Dominio.Entidade;
using UADDD.Dominio.Interfaces.Servicos;
using UADDD.Infraestrutura.CrossCuting.AutoMapper;

namespace UADDD.Aplicacao.Servicos
{
    public class AlunoServicoAplicacao : BaseServicoAplicacao<Aluno>, IAlunoServicoAplicacao
    {
        public readonly IAlunoServicoDominio _alunoServicoDominio;
        public readonly IMapperAluno _mapperAluno;

        public AlunoServicoAplicacao(IAlunoServicoDominio alunoServicoDominio, IMapperAluno mapperAluno)
            : base(alunoServicoDominio)
        {
            _alunoServicoDominio = alunoServicoDominio;
            _mapperAluno = mapperAluno;
        }

        public void Adicionar(AlunoDTO obj)
        {
            var aluno = _mapperAluno.MapperToEntity(obj);
            _alunoServicoDominio.Adicionar(aluno);
        }

        public IEnumerable<AlunoDTO> Listar()
        {
            var alunos = _alunoServicoDominio.Listar();
            return _mapperAluno.MapperListAlunos(alunos);
        }

        public Aluno DetalharPorNome(string busca)
        {
            return _alunoServicoDominio.DetalharPorNome(busca);
        }

        public IEnumerable<Aluno> ListarAlunosAtivos()
        {
            return _alunoServicoDominio.ListarAlunosAtivos();
        }

        AlunoDTO IAlunoServicoAplicacao.DetalharId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(AlunoDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(AlunoDTO obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlunoDTO> IAlunoServicoAplicacao.ListarAlunosAtivos()
        {
            throw new NotImplementedException();
        }
    }
}
