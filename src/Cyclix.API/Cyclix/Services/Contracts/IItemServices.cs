using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IItemServices
{
    ICollection<ItemReadDto> GetItems();
}