using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class OptionReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public OptionReadDto(Option option)
    {
        Id = option.Id;
        Name = option.Name;
    }
    
    public OptionReadDto(RequestOption option)
    {
        Id = option.Option.Id;
        Name = option.Option.Name;
    }
}