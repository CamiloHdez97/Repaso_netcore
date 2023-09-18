using System.Linq.Expressions;
using Core.Estities;
using Core.interfaces;
using FluentValidation;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository;

public class PaisRepository : IPais{

    protected readonly InventarioContext _context;

    public PaisRepository(InventarioContext context)
    {
        _context = context;
    }

    public virtual void Add(Pais entity)
    {
        _context.Set<Pais>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<Pais> entities)
    {
        _context.Set<Pais>().AddRange(entities);
    }

    public IEnumerable<Pais> Find(Expression<Func<Pais, bool>> expression)
    {
        return _context.Set<Pais>().Where(expression);
    }

    public async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Set<Pais>().ToListAsync();
    }

    public async Task<Pais> GetByIdAsync(string id)
    {
        return await _context.Set<Pais>().FindAsync(id);
    }

    public void Remove(Pais entity)
    {
        _context.Set<Pais>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<Pais> entities)
    {
        _context.Set<Pais>().RemoveRange(entities);
    }

    public void Update(Pais entity)
    {
        _context.Set<Pais>().Update(entity);
    }

}