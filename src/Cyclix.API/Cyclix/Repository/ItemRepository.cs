using Cyclix.Entities;

namespace Cyclix.Repository;

public class ItemRepository : RepositoryBase<Item>, IItemRepository
{
    public ItemRepository(RepositoryContext context) : base(context)
    {
        
    }
}