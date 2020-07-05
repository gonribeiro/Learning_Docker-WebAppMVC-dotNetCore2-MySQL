using System;
using System.Collections.Generic;
using UADDD.Aplicacao.DTO;
using UADDD.Dominio.Entidade;

namespace UADDD.Infraestrutura.CrossCuting.AutoMapper
{
    public interface IMapperAluno
    {
        Aluno MapperToEntity(AlunoDTO alunoDTO);
        IEnumerable<AlunoDTO> MapperListAlunos(IEnumerable<Aluno> Alunos);
        AlunoDTO MapperToDTO(Aluno aluno);
    }
}
