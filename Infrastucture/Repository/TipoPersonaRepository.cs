using System.Linq.Expressions;
using Core.Estities;
using Core.interfaces;
using FluentValidation;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository;

public class TipoPersonaRepository : ITipoPersona{

    protected readonly InventarioContext _context;

    public TipoPersonaRepository(InventarioContext context)
    {
        _context = context;
    }

    public virtual void Add(TipoPersona entity)
    {
        _context.Set<TipoPersona>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<TipoPersona> entities)
    {
        _context.Set<TipoPersona>().AddRange(entities);
    }

    public IEnumerable<TipoPersona> Find(Expression<Func<TipoPersona, bool>> expression)
    {
        return _context.Set<TipoPersona>().Where(expression);
    }

    public async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.Set<TipoPersona>().ToListAsync();
    }

    public async Task<TipoPersona> GetByIdAsync(string id)
    {
        return await _context.Set<TipoPersona>().FindAsync(id);
    }

    public void Remove(TipoPersona entity)
    {
        _context.Set<TipoPersona>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<TipoPersona> entities)
    {
        _context.Set<TipoPersona>().RemoveRange(entities);
    }

    public void Update(TipoPersona entity)
    {
        _context.Set<TipoPersona>().Update(entity);
    }

}