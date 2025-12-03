using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;


namespace DAL.Produtos
{
    internal class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);
            builder
                .Property(l => l.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.Status).HasDefaultValue(true);

        }
    }
}
