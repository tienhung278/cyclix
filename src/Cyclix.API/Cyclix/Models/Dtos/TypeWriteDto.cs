namespace Cyclix.Models.Dtos;

public class TypeWriteDto
{
    public string Name { get; set; }
    
    public Entities.Type ToType()
    {
        return new Entities.Type
        {
            Name = Name
        };
    }
}