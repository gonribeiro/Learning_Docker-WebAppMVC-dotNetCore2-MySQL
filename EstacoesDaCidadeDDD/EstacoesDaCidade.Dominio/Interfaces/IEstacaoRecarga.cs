using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Dominio.Entidades;

namespace EstacoesDaCidade.Dominio.Interfaces
{
    public interface IEstacaoRecarga : IBase<EstacaoRecarga>
    {
        //Herdar todos os métodos de IBase
        //TODO: Outros contratos relevantes para produto
        //Exemplo: RecuperarPorNome()

        EstacaoRecarga RecuperarPorNome(string nome);
    }
}
