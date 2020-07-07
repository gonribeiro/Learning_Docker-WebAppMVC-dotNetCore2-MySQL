using Microsoft.EntityFrameworkCore;
using BokuNoHeroAcademia.Models;

namespace BokuNoHeroAcademia.Data
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext (DbContextOptions<AcademiaContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<Estudante> Estudante { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<CursoAtribuido> CursoAtribuido { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoAtribuido>()
                .HasKey(c => new { c.CursoID, c.ProfessorID });
        }
    }
}
