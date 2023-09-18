using Core.Estities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Configuration;

public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    { 
        builder.ToTable("TipoPersona");
        builder.Property(p => p.Id).IsRequired();

        builder.Property(p => p.Description).IsRequired();
    }

    
}