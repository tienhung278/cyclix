using Cyclix.Entities;

namespace Cyclix.Repository;

public class RequestOptionRepository : RepositoryBase<RequestOption>, IRequestOptionRepository
{
    public RequestOptionRepository(RepositoryContext context) : base(context)
    {
        
    }
}