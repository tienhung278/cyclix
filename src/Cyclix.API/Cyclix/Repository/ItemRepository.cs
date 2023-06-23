using Cyclix.Entities;

namespace Cyclix.Repository;

public class ItemRepository : RepositoryBase<Item>, IItemRepository
{
    private readonly RepositoryContext _context;

    public ItemRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }
    
    public ICollection<Item> GetItems()
    {
        return FindAll().ToList();
    }
}