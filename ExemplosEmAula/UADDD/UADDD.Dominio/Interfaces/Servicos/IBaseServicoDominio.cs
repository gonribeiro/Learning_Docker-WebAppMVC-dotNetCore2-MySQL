using System;
using System.Collections.Generic;
using System.Text;

namespace UADDD.Dominio.Interfaces.Servicos
{
    public interface IBaseServicoDominio<T> where T : class
    {
        void Adicionar(T obj);
        T DetalharId(int Id);
        IEnumerable<T> Listar();
        void Atualizar(T obj);
        void Excluir(T obj);
        void Dispose();
    }
}
