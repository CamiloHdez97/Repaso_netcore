using System.IO.Compression;
using Core.Estities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Configuration;

public class PersonaProductoConfiguration : IEntityTypeConfiguration<PersonaProducto> {

    public void Configure(EntityTypeBuilder<PersonaProducto> builder){

        builder.ToTable("PersonaProducto");
        builder.HasOne(p => p.Personas).WithMany(p => p.PersonaProductos).HasForeignKey(f => f.IdPersona);
        builder.HasOne(p => p.Productos).WithMany(p => p.PersonaProductos).HasForeignKey(f => f.IdProducto);
        
    }

}