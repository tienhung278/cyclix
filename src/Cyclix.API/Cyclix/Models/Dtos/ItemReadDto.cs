using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class ItemReadDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public ItemReadDto(Item item)
    {
        Id = item.Id;
        Name = item.Name;
        Category = item.Category;
    }
}