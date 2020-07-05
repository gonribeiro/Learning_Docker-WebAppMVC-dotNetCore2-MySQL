using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using almoxarifado.Models;

namespace almoxarifado.Models
{
    public class AlmoxarifadoContext : DbContext
    {
        public AlmoxarifadoContext(DbContextOptions<AlmoxarifadoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
    }
}
