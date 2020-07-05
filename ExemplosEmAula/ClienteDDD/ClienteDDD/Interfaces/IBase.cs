using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteDDD.Dominio.Interfaces
{
    public interface IBase<T> where T : class
    {
        void Adicionar(T obj);

        T RecuperarPorId(Guid id);

        void Atualizar(T obj);

        void Excluir(T obj);

        IList<T> Listar();
    }

    
    
}
