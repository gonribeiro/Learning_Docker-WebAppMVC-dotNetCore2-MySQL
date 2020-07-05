using System;
using System.Collections.Generic;
using System.Text;
using UADDD.Aplicacao.DTO;
using UADDD.Dominio.Entidade;

namespace UADDD.Aplicacao.Interfaces
{
    public interface IAlunoServicoAplicacao : IBaseServicoAplicacao<Aluno>
    {
        void Adicionar(AlunoDTO obj);
        AlunoDTO DetalharId(int id);
        IEnumerable<AlunoDTO> Listar();
        void Atualizar(AlunoDTO obj);
        void Excluir(AlunoDTO obj);
        void Dispose();
        Aluno DetalharPorNome(string busca);
        IEnumerable<AlunoDTO> ListarAlunosAtivos();
    }
}
