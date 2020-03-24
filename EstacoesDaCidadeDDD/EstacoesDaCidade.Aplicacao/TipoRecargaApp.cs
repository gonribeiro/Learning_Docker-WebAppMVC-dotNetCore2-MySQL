using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Aplicacao.Interfaces;
using EstacoesDaCidade.Dominio.Entidades;
using EstacoesDaCidade.Dominio.Interfaces;

namespace EstacoesDaCidade.Aplicacao
{
    public class TipoRecargaApp : ITipoRecargaApp
    {
        private readonly ITipoRecarga _tipoRecargaInterface;

        public TipoRecargaApp(ITipoRecarga tipoRecargaInterface)
        {
            _tipoRecargaInterface = tipoRecargaInterface;
        }

        public void Adicionar(TipoRecarga obj)
        {
            _tipoRecargaInterface.Adicionar(obj);
        }

        public void Atualizar(TipoRecarga obj)
        {
            _tipoRecargaInterface.Atualizar(obj);
        }

        public void Excluir(TipoRecarga obj)
        {
            _tipoRecargaInterface.Excluir(obj);
        }

        public IList<TipoRecarga> Listar()
        {
            return _tipoRecargaInterface.Listar();
        }

        public TipoRecarga RecuperarPorId(Guid id)
        {
            return _tipoRecargaInterface.RecuperarPorId(id);
        }
    }
}