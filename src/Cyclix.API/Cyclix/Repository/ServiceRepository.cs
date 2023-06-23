using Cyclix.Entities;

namespace Cyclix.Repository;

public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(RepositoryContext context) : base(context)
    {
        
    }
}