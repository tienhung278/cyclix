using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class ItemServices : IItemServices
{
    private readonly IItemRepository _itemRepository;

    public ItemServices(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public ICollection<ItemReadDto> GetItems()
    {
        return Array.ConvertAll(_itemRepository.GetItems().ToArray(), i => new ItemReadDto(i));
    }
}