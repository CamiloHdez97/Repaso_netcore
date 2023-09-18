namespace Core.interfaces;

public interface IUnitOfWork
{
    IPais Paises { get; }
    IEstado Estados { get; }
    IPersona Personas { get; }
    IPersonaProducto PersonaProductos { get; }
    IProducto Productos { get; }
    IRegion Regiones { get; }
    ITipoPersona TipoPersonas { get; }

    Task<int> SaveAsync();

}