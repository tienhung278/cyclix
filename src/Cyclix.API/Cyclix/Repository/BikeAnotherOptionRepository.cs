using Cyclix.Entities;

namespace Cyclix.Repository;

public class BikeAnotherOptionRepository : RepositoryBase<BikeAnotherOption>, IBikeAnotherOptionRepository
{
    public BikeAnotherOptionRepository(RepositoryContext context) : base(context)
    {
        
    }
}