using ClienteDDD.Dominio.Entidades;
using ClienteDDD.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteDDD.Infra.Dados.Repositorio
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, ICliente
    {
    }
}
