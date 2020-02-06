using Lims.Domain.Enum;

namespace Lims.Domain.Entities
{
    /// <summary>
    /// Entidade Atleta
    /// </summary>
    public class Atleta
    {      
        public string CodAtleta { get; set; }
        public Sexo Sexo { get; set; }
        public Modalidade Modalidade { get; set; }
    }
}
