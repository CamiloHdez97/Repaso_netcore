using System.Linq.Expressions;
using Core.Estities;
using Core.interfaces;
using FluentValidation;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository;

public class EstadoRepository : IEstado{

    protected readonly InventarioContext _context;

    public EstadoRepository(InventarioContext context)
    {
        _context = context;
    }

    public virtual void Add(Estado entity)
    {
        _context.Set<Estado>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<Estado> entities)
    {
        _context.Set<Estado>().AddRange(entities);
    }

    public IEnumerable<Estado> Find(Expression<Func<Estado, bool>> expression)
    {
        return _context.Set<Estado>().Where(expression);
    }

    public async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Set<Estado>().ToListAsync();
    }

    public async Task<Estado> GetByIdAsync(string id)
    {
        return await _context.Set<Estado>().FindAsync(id);
    }

    public void Remove(Estado entity)
    {
        _context.Set<Estado>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<Estado> entities)
    {
        _context.Set<Estado>().RemoveRange(entities);
    }

    public void Update(Estado entity)
    {
        _context.Set<Estado>().Update(entity);
    }

}