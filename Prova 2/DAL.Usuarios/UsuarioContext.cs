using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Usuarios
{
    public class UsuarioContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
        }
    
    }
}
