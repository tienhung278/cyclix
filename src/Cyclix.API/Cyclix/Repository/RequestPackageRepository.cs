using Cyclix.Entities;

namespace Cyclix.Repository;

public class RequestPackageRepository : RepositoryBase<RequestPackage>, IRequestPackageRepository
{
    public RequestPackageRepository(RepositoryContext context) : base(context)
    {
        
    }
}