using System.Linq.Expressions;
using Cyclix.Entities.Common;

namespace Cyclix.Repository;

public interface IRepositoryBase<T> where T : class
{
    Task<IReadOnlyList<T>> FindAllAsync();
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true);
    Task<T> FindByIdAsync(long id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}