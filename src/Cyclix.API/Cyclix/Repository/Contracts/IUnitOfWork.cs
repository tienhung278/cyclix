namespace Cyclix.Repository;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}