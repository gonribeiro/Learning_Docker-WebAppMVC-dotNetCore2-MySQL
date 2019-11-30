using Microsoft.EntityFrameworkCore;

namespace webapp.Models.ProductContext
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Conexão BD
            optionsBuilder.UseMySQL("server=localhost;port=3306;userid=root;password=;database=webapi;");

            // Conexão compilando apenas o MySQL via docker (exemplo)
            // optionsBuilder.UseMySQL("server=localhost;port=3333;userid=root;password=123456;database=amazingdb;");

            // Conexão compilando a aplicação .NET e MySQL juntas via docker (exemplo)
            // optionsBuilder.UseMySQL("server=db;port=3306;userid=root;password=123456;database=amazingdb;");
        }

        public ProductContext()
        {
            Database.EnsureCreated();
        }
    }
}
