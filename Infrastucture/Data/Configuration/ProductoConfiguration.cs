using Core.Estites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomelo.EntityFrameworkCore.MySql.Metadata.Conventions;

namespace Infrastucture.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Producto");
        builder.Property(p => p.IdProducto).HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn).HasMaxLength(10).IsRequired();

        builder.Property(p => p.NombreProducto).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Descripcion).IsRequired().HasColumnType("text");
        builder.Property(p => p.Precio).IsRequired().HasColumnType("double");
        builder.Property(p => p.StockMinimo).IsRequired().HasColumnType("int");
        builder.Property(p => p.StockMaximo).IsRequired().HasColumnType("int");

    }
}