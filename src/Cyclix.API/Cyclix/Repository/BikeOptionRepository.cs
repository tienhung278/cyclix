using Cyclix.Entities;

namespace Cyclix.Repository;

public class BikeOptionRepository : RepositoryBase<BikeOption>, IBikeOptionRepository
{
    public BikeOptionRepository(RepositoryContext context) : base(context)
    {
        
    }
}