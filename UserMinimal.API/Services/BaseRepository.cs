using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserMinimal.API.Constants;
using UserMinimal.API.Data;
using UserMinimal.API.Interfaces;

namespace Repository_With_UOW.EntityFrameworkCore.Services;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public T GetById(Guid id) => _context.Set<T>().Find(id);

    public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

    public List<T> GetAll() => _context.Set<T>().ToList();

    public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes is not null)
            foreach (string include in includes)
                query = query.Include(include);

        return _context.Set<T>().SingleOrDefault(criteria);
    }

    public List<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes is not null)
            foreach (string include in includes)
                query = query.Include(include);

        return _context.Set<T>().Where(criteria).ToList();
    }

    public List<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes is not null)
            foreach (string include in includes)
                query = query.Include(include);

        return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
    }

    public List<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take, string[] includes = null, Expression<Func<T, object>> orderBy = null, string orderbyDirection = OrderBy.Asending)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes is not null)
            foreach (string include in includes)
                query = query.Include(include);

        query = query.Where(criteria);

        query = skip.HasValue ? query.Skip(skip.Value) : query;

        query = take.HasValue ? query.Take(take.Value) : query;

        if (orderBy is not null)
            query = string.Equals(orderbyDirection, OrderBy.Asending, StringComparison.OrdinalIgnoreCase) ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

        return query.ToList();
    }

    public T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }
    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public List<T> AddRange(List<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        _context.SaveChanges();
        return entities;
    }
    public async Task<List<T>> AddRangeAsync(List<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }
    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return entity;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public bool Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        int result = _context.SaveChanges();
        return result > 0;
    }
    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }
    public bool DeleteRange(List<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        int result = _context.SaveChanges();
        return result > 0;
    }
    public async Task<bool> DeleteRangeAsync(List<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }
    public void Attach(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.SaveChanges();
    }
    public int Count()
    {
        return _context.Set<T>().Count();
    }
    public int Count(Expression<Func<T, bool>> criteria)
    {
        return _context.Set<T>().Count(criteria);
    }


}
