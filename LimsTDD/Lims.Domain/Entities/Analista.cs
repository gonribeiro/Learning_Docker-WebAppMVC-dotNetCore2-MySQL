using System;
using System.Collections.Generic;
using System.Text;
using Lims.Domain.Entities;
using Lims.Domain.Interfaces;
using Lims.Domain.Services;

namespace Lims.Domain.Entities
{
    /// <summary>
    /// Representa a entidade Analista, o responsável pela análise da entidade Amostra
    /// </summary>
    public class Analista
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}

