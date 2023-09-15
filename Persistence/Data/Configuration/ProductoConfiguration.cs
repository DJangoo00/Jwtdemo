using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Producto");

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Nombre)
                .HasColumnName("prodName")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

                builder.Property(p => p.Precio)
                .HasColumnName("prodPrecio")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

                builder.Property(p => p.FechaCreacion)
                .HasColumnName("prodFechaCreacion")
                .HasColumnType("date");

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.CategoriaId);

            builder.HasOne(p => p.Marca)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.MarcaId);
        }
    }
}