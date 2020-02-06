using System;
using System.Collections.Generic;
using System.Text;
using Lims.Domain.Entities;
using Lims.Domain.Enum;
using Lims.Domain.Interfaces;
using Lims.Domain.Services;

namespace Lims.Domain.Entities
{
    /// <summary>
    /// Representa a entidade Amostra, que pertence a uma análise a 
    /// ser executada e conclusiva
    /// </summary>
    public class Amostra
    {
        public Guid Id { get; set; } 
        public Atleta Atleta { get; set; }
        public DateTime DataColeta { get; set; }
        public Matriz Matriz { get; set; } //Sangue, Urina e Outros
        public string Laudo { get; set; } //Positivo e Negativo
        public Analista Analista { get; set; } //Responsável pelo laudo
        public string Substancia { get; set; } //Encontrada na Amostra
    }
}
