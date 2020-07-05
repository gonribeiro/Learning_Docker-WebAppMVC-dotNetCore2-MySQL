using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UADDD.Dominio.Entidade;
using UADDD.Infraestrutura.Persistencia.configuracoes;

namespace UADDD.Infraestrutura.Persistencia
{
    public class UADbContext : DbContext
    {

        public UADbContext(DbContextOptions<UADbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=UADDD;Trusted_Connection = True;");
        }

        // Mapeia todos os modelos que possuem propriedade string e transforma para varchar(255)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (prop.GetColumnType() == null)
                    prop.SetColumnType("varchar(255)");
            }

            // Customizando a tabela aluno (exemplo se necessário)
            modelBuilder.ApplyConfiguration(new AlunoConfiguracao());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
