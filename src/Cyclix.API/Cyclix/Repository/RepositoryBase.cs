using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Cyclix.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext context;
    private readonly DbSet<T> table;

    public RepositoryBase(RepositoryContext context)
    {
        this.context = context;
        table = context.Set<T>();
    }

    public void Add(T entity)
    {
        table.AddAsync(entity);
    }

    public IQueryable<T> FindAll()
    {
        return table.AsNoTracking();
    }
}