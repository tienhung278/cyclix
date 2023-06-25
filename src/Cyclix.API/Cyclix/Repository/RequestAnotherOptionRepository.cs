using Cyclix.Entities;

namespace Cyclix.Repository;

public class RequestAnotherOptionRepository : RepositoryBase<RequestAnotherOption>, IRequestAnotherOptionRepository
{
    public RequestAnotherOptionRepository(RepositoryContext context) : base(context)
    {
        
    }
}