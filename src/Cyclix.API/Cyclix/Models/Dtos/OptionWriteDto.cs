using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class OptionWriteDto
{
    public string Name { get; set; }
    
    public Option ToOption()
    {
        return new Option
        {
            Name = Name
        };
    }
}