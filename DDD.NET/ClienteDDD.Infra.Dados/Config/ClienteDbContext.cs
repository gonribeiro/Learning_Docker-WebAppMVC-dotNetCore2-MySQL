using ClienteDDD.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteDDD.Infra.Dados.Config
{
    public class ClienteDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }


        public ClienteDbContext()
        {

        }

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            //Alterar para configurações desejadas:
            return "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=ClienteDDD;" +
                "Trusted_Connection=True;" +
                "MultipleActiveResultSets=True;";
        }
    }
}
