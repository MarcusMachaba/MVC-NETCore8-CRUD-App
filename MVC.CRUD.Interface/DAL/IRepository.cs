using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MVC.CRUD.Interface.DAL;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);
    Task InsertAsync(T obj);
    Task UpdateAsync(T obj);
    Task DeleteAsync(object id);
    Task SaveAsync();
    IQueryable<T> Search(Expression<Func<T, bool>> predicate);
}

public class Repository<T> : IRepository<T> where T : class
{
    private CRUDContext _context = null;
    private DbSet<T> table = null;

    public Repository()
    {
        _context = new CRUDContext();
        table = _context.Set<T>();
    }

    public Repository(CRUDContext context)
    {
        _context = context;
        table = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await table.ToListAsync();
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await table.FindAsync(id);
    }

    public async Task InsertAsync(T obj)
    {
        await table.AddAsync(obj);
    }

    public async Task UpdateAsync(T obj)
    {
        table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(object id)
    {
        T existing = await table.FindAsync(id);
        if (existing != null)
            table.Remove(existing);
        await Task.CompletedTask;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
    {
        return table.Where(predicate);
    }
}
