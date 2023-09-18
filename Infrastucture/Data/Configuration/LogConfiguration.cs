using Core.Estities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Configuration;

public class LogConfiguration : IEntityTypeConfiguration<Log> {

    public void Configure(EntityTypeBuilder<Log> builder){

        builder.ToTable("Log");
        builder.HasKey(e => e.IdLog);
        builder.Property(e => e.IdLog).ValueGeneratedNever(); //Quitar autoincrementeal

        builder.Property(e => e.FechaRegistro).HasColumnType("date");

        builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);

    }

}