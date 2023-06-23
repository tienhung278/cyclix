using Cyclix.Entities;

namespace Cyclix.Repository;

public class PackageRepository : RepositoryBase<Package>, IPackageRepository
{
    public PackageRepository(RepositoryContext context) : base(context)
    {
        
    }
}