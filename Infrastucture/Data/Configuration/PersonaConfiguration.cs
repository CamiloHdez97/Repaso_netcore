using System.IO.Compression;
using Core.Estities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.Property(p => p.IdPersona).HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn).IsRequired().HasMaxLength(15);
        builder.Property(p => p.Nombre).IsRequired();
        builder.Property(p => p.Apellido).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.HasOne(p => p.TipoPersona).WithMany(e => e.Personas).HasForeignKey(f => f.IdTipoPersona);
        builder.HasOne(p => p.Region).WithMany(r => r.Personas).HasForeignKey(f => f.IdRegion);
    }

}