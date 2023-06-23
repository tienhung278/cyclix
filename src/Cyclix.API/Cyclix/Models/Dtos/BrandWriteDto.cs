using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class BrandWriteDto
{
    public string Name { get; set; }

    public Brand ToBrand()
    {
        return new Brand
        {
            Name = Name
        };
    }
}