using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class ServiceReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public ServiceReadDto(Service service)
    {
        Id = service.Id;
        Name = service.Name;
    }
}