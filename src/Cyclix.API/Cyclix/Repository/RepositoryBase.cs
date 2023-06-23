using System.Linq.Expressions;
using Cyclix.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Cyclix.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext context;

    public RepositoryBase(RepositoryContext context)
    {
        this.context = context;
    }

    public async Task<IReadOnlyList<T>> FindAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null,
        bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();
        
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (!string.IsNullOrWhiteSpace(includeString) != null)
        {
            query = query.Include(includeString);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }

        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true)
    {
        IQueryable<T> query = context.Set<T>();
        
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (includes.Count > 0)
        {
            query = includes.Aggregate(query, (query, include) => query.Include(include));
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }

        return await query.ToListAsync();
    }

    public async Task<T> FindByIdAsync(long id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
    }
}