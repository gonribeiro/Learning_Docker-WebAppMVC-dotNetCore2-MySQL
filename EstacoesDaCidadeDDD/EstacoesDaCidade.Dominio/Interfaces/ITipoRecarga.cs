using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Dominio.Entidades;

namespace EstacoesDaCidade.Dominio.Interfaces
{
    public interface ITipoRecarga : IBase<TipoRecarga>
    {
        //Herdar todos os métodos de IBase
        //TODO: Outros contratos relevantes para produto
        //Exemplo: RecuperarPorNome()

        TipoRecarga RecuperarPorNome(string nome);
    }
}