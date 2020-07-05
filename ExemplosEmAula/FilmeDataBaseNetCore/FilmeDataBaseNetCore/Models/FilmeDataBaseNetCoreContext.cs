using Microsoft.EntityFrameworkCore;

namespace FilmeDataBaseNetCore.Models
{
    public class FilmeDataBaseNetCoreContext : DbContext
    {
        public FilmeDataBaseNetCoreContext(DbContextOptions<FilmeDataBaseNetCoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .HasOne(a => a.Genero)
                .WithMany(b => b.Filme)
                .IsRequired();
        }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
