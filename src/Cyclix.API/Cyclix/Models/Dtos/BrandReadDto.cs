using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class BrandReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }

    public BrandReadDto(Brand brand)
    {
        Id = brand.Id;
        Name = brand.Name;
    }
}