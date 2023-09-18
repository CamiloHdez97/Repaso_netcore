using Core.interfaces;
using Infrastucture.Data;
using Infrastucture.Repository;

namespace Infrastucture.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{

    private readonly InventarioContext context;
    private IPais _paises;
    private IEstado _estados;
    private IPersona _personas;
    private IPersonaProducto _personaProductos;
    private IProducto _productos;
    private IRegion _regiones;
    private ITipoPersona _tipoPersonas;

    public UnitOfWork(InventarioContext _context)
    {
        context = _context; 
    }

    public IPais Paises
	{
		get
		{
		    if (_paises == null)
			{
			    _paises = new PaisRepository(context);
			}
			    return _paises;
		}
	}

    public IEstado Estados
	{
		get
		{
		    if (_estados == null)
			{
			    _estados = new EstadoRepository(context);
			}
			    return _estados;
		}
	}

    public IPersona Personas
	{
		get
		{
		    if (_personas == null)
			{
			    _personas = new PersonaRepository(context);
			}
			    return _personas;
		}
	}

    public IPersonaProducto PersonaProductos
	{
		get
		{
		    if (_personaProductos == null)
			{
			    _personaProductos = new PersonaProductoRepository(context);
			}
			    return _personaProductos;
		}
	}

    public IRegion Regiones
	{
		get
		{
		    if (_regiones == null)
			{
			    _regiones = new RegionRepository(context);
			}
			    return _regiones;
		}
	}

    public ITipoPersona TipoPersonas
	{
		get
		{
		    if (_tipoPersonas == null)
			{
			    _tipoPersonas = new TipoPersonaRepository(context);
			}
			    return _tipoPersonas;
		}
	}

    public IProducto Productos
	{
		get
		{
		    if (_productos == null)
			{
			    _productos = new ProductoRepository(context);
			}
			    return _productos;
		}
	}


    public void Dispose()
    {
        context.Dispose();
    }

    public int Save()
    {
        return context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}