using System.Linq.Expressions;

namespace Cyclix.Repository;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll();
    void Add(T entity);
}