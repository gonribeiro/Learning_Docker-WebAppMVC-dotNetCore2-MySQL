using System;
using System.Collections.Generic;
using System.Text;

namespace UADDD.Dominio.Interfaces.Repositorios
{
    public interface IBaseRepositorio<T> where T: class
    {
        void Adicionar(T obj);
        T DetalharId(int Id);
        IEnumerable<T> Listar();
        void Atualizar(T obj);
        void Excluir(T obj);
        void Dispose();
    }
}
