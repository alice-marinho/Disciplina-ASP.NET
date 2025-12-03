using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Produtos
{

    public class ProdutoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Produto>(new ProdutoConfiguration());
        }
    }
}

