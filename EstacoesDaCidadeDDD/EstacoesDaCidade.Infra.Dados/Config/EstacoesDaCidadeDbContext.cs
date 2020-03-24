using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EstacoesDaCidade.Dominio.Entidades;

namespace EstacoesDaCidade.Infra.Dados.Config
{
    public class EstacoesDaCidadeDbContext : DbContext
    {
        public DbSet<EstacaoRecarga> EstacoesRecarga { get; set; }
        public DbSet<TipoRecarga> TipoRecarga { get; set; }

        public EstacoesDaCidadeDbContext()
        {
        }

        public EstacoesDaCidadeDbContext(DbContextOptions<EstacoesDaCidadeDbContext> options) : base(options)
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
            return "Server=(localdb)\\MSSQLLocalDB;Database=EstacoesDaCidade;Trusted_Connection=True;MultipleActiveResultSets=True;";
        }
    }
}
