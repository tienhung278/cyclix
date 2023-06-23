using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class AnotherOptionReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public AnotherOptionReadDto(AnotherOption option)
    {
        Id = option.Id;
        Name = option.Name;
    }
    
    public AnotherOptionReadDto(BikeAnotherOption option)
    {
        Id = option.AnotherOption.Id;
        Name = option.AnotherOption.Name;
    }
}