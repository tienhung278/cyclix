using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class PackageWriteDto
{
    public string Name { get; set; }
    
    public Package ToPackage()
    {
        return new Package
        {
            Name = Name
        };
    }
}