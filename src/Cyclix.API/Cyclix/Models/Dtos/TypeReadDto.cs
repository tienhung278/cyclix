namespace Cyclix.Models.Dtos;

public class TypeReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public TypeReadDto(Entities.Type type)
    {
        Id = type.Id;
        Name = type.Name;
    }
}