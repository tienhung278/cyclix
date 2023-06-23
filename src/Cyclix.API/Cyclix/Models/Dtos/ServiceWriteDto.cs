using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class ServiceWriteDto
{
    public string Name { get; set; }
    
    public Service ToService()
    {
        return new Service
        {
            Name = Name
        };
    }
}