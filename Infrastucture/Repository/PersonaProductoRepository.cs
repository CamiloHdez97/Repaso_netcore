using System.Linq.Expressions;
using Core.Estities;
using Core.interfaces;
using FluentValidation;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository;

public class PersonaProductoRepository : IPersonaProducto{

    protected readonly InventarioContext _context;

    public PersonaProductoRepository(InventarioContext context)
    {
        _context = context;
    }

    public virtual void Add(PersonaProducto entity)
    {
        _context.Set<PersonaProducto>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<PersonaProducto> entities)
    {
        _context.Set<PersonaProducto>().AddRange(entities);
    }

    public IEnumerable<PersonaProducto> Find(Expression<Func<PersonaProducto, bool>> expression)
    {
        return _context.Set<PersonaProducto>().Where(expression);
    }

    public async Task<IEnumerable<PersonaProducto>> GetAllAsync()
    {
        return await _context.Set<PersonaProducto>().ToListAsync();
    }

    public async Task<PersonaProducto> GetByIdAsync(string id)
    {
        return await _context.Set<PersonaProducto>().FindAsync(id);
    }

    public void Remove(PersonaProducto entity)
    {
        _context.Set<PersonaProducto>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<PersonaProducto> entities)
    {
        _context.Set<PersonaProducto>().RemoveRange(entities);
    }

    public void Update(PersonaProducto entity)
    {
        _context.Set<PersonaProducto>().Update(entity);
    }

}