using Cyclix.Entities;

namespace Cyclix.Repository;

public class AnotherOptionRepository : RepositoryBase<AnotherOption>, IAnotherOptionRepository
{
    public AnotherOptionRepository(RepositoryContext context) : base(context)
    {
        
    }
}