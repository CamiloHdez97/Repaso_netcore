using System.Reflection;
using Core.Estities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data;

public class InventarioContext : DbContext
{
    public InventarioContext(DbContextOptions<InventarioContext> options) : base(options)
    {
    }
    public DbSet<Pais> Paises {get; set;}
    public DbSet<Estado> Estados {get; set;}
    public DbSet<Region> Regiones {get; set;}
    public DbSet<Persona> Personas {get; set;}
    public DbSet<TipoPersona> TipoPersonas {get; set;}
    public DbSet<Producto> Productos {get; set;}
    public DbSet<PersonaProducto> PersonaProductos {get; set;}
    // public DbSet<Ciudad> Ciudades {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonaProducto>().HasKey(r => new {r.IdPersona, r.IdProducto});
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

} 