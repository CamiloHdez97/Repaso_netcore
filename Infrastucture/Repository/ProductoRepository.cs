using System.Linq.Expressions;
using Core.Estities;
using Core.interfaces;
using FluentValidation;
using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository;

public class ProductoRepository : IProducto{

    protected readonly InventarioContext _context;

    public ProductoRepository(InventarioContext context)
    {
        _context = context;
    }

    public virtual void Add(Producto entity)
    {
        _context.Set<Producto>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<Producto> entities)
    {
        _context.Set<Producto>().AddRange(entities);
    }

    public IEnumerable<Producto> Find(Expression<Func<Producto, bool>> expression)
    {
        return _context.Set<Producto>().Where(expression);
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Set<Producto>().ToListAsync();
    }

    public async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Set<Producto>().FindAsync(id);
    }

    public void Remove(Producto entity)
    {
        _context.Set<Producto>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<Producto> entities)
    {
        _context.Set<Producto>().RemoveRange(entities);
    }

    public void Update(Producto entity)
    {
        _context.Set<Producto>().Update(entity);
    }

}