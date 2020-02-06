using System;
using System.Collections.Generic;
using System.Text;
using Lims.Domain.Entities;
using Lims.Domain.Interfaces;
using Lims.Domain.Services;

namespace Lims.Domain.Entities
{
    /// <summary>
    /// Representa a entidade Modalidade que é o esporte do atleta/amostra
    /// </summary>
    public class Modalidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
