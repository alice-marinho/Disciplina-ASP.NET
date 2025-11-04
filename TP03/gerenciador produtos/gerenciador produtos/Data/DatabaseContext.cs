using gerenciador_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_produtos.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Preco)
                .HasPrecision(18, 2);
        }
    }
}
