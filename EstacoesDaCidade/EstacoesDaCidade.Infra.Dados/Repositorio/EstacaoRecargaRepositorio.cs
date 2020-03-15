using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Dominio.Entidades;
using EstacoesDaCidade.Dominio.Interfaces;

namespace EstacoesDaCidade.Infra.Dados.Repositorio
{
    public class EstacaoRecargaRepositorio : RepositorioBase<EstacaoRecarga>, IEstacaoRecarga
    {
        //Por herança já possui os métodos CRUD 
        //Por Implementar IProduto, precisa implementar o método RecuperarPorNome:
        public EstacaoRecarga RecuperarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
