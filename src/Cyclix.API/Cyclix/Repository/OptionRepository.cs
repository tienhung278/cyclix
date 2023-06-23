using Cyclix.Entities;

namespace Cyclix.Repository;

public class OptionRepository : RepositoryBase<Option>, IOptionRepository
{
    public OptionRepository(RepositoryContext context) : base(context)
    {
        
    }
}