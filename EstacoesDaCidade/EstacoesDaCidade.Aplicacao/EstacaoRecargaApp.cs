using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Aplicacao.Interfaces;
using EstacoesDaCidade.Dominio.Entidades;
using EstacoesDaCidade.Dominio.Interfaces;

namespace EstacoesDaCidade.Aplicacao
{
    public class EstacaoRecargaApp : IEstacaoRecargaApp
    {
        private readonly IEstacaoRecarga _estacaoRecargaInterface;

        public EstacaoRecargaApp(IEstacaoRecarga estacaoRecargaInterface)
        {
            _estacaoRecargaInterface = estacaoRecargaInterface;
        }

        public void Adicionar(EstacaoRecarga obj)
        {
            _estacaoRecargaInterface.Adicionar(obj);
        }

        public void Atualizar(EstacaoRecarga obj)
        {
            _estacaoRecargaInterface.Atualizar(obj);
        }

        public void Excluir(EstacaoRecarga obj)
        {
            _estacaoRecargaInterface.Excluir(obj);
        }

        public IList<EstacaoRecarga> Listar()
        {
            return _estacaoRecargaInterface.Listar();
        }

        public EstacaoRecarga RecuperarPorId(Guid id)
        {
            return _estacaoRecargaInterface.RecuperarPorId(id);
        }
    }
}
