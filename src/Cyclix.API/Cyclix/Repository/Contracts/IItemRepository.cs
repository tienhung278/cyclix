using Cyclix.Entities;

namespace Cyclix.Repository;

public interface IItemRepository : IRepositoryBase<Item>
{
    ICollection<Item> GetItems();
}