using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class AnotherOptionWriteDto
{
    public string Name { get; set; }
    
    public AnotherOption ToAnotherOption()
    {
        return new AnotherOption
        {
            Name = Name
        };
    }
}