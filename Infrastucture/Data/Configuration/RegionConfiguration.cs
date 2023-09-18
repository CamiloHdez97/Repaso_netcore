using Core.Estities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Configuration;

public class RegionConfiguration : IEntityTypeConfiguration<Region>{

    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Region");
        builder.Property(p => p.CodRegion)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasMaxLength(3);

        builder.Property(p => p.NomRegion)
       .IsRequired()
       .HasMaxLength(50);

        builder.HasOne(p => p.Estado)
        .WithMany(p => p.Regiones)
        .HasForeignKey(p=> p.CodEstado);

    }

}