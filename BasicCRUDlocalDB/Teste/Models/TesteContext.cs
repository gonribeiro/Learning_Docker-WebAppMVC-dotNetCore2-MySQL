using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
