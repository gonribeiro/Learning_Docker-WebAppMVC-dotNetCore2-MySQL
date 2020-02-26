using System;
using System.Collections.Generic;
using System.Text;
using ClienteDDD.Dominio.Entidades;

namespace ClienteDDD.Dominio.Interfaces
{
    public interface ICliente : IBase<Cliente>
    {
        //Herdando todos os métodos de IBase
        public Cliente RecuperarPorNome (string nome)
        {
            throw new NotImplementedException();

        }
    }
}
