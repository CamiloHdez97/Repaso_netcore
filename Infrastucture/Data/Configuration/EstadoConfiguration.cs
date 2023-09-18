using Core.Estities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastucture.Data.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>{

    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        
        builder.ToTable("Estado");

        builder.Property(p => p.CodEstado)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn).HasMaxLength(3);

        builder.Property(p => p.NomEstado)
       .IsRequired().HasMaxLength(50);
    
        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Estados)
        .HasForeignKey(p => p.CodPais);

    }

}