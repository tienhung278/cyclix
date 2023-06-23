using Cyclix.Entities;

namespace Cyclix.Repository;

public class BikePackageRepository : RepositoryBase<BikePackage>, IBikePackageRepository
{
    public BikePackageRepository(RepositoryContext context) : base(context)
    {
        
    }
}