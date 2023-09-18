using System.Linq.Expressions;
using Core.Estities;
using Core.interfaces;
using FluentValidation;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository;

public class RegionRepository : IRegion{

    protected readonly InventarioContext _context;

    public RegionRepository(InventarioContext context)
    {
        _context = context;
    }

    public virtual void Add(Region entity)
    {
        _context.Set<Region>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<Region> entities)
    {
        _context.Set<Region>().AddRange(entities);
    }

    public IEnumerable<Region> Find(Expression<Func<Region, bool>> expression)
    {
        return _context.Set<Region>().Where(expression);
    }

    public async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _context.Set<Region>().ToListAsync();
    }

    public async Task<Region> GetByIdAsync(string id)
    {
        return await _context.Set<Region>().FindAsync(id);
    }

    public void Remove(Region entity)
    {
        _context.Set<Region>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<Region> entities)
    {
        _context.Set<Region>().RemoveRange(entities);
    }

    public void Update(Region entity)
    {
        _context.Set<Region>().Update(entity);
    }

}