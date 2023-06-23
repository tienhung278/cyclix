using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class PackageReadDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public PackageReadDto(Package package)
    {
        Id = package.Id;
        Name = package.Name;
    }
    
    public PackageReadDto(BikePackage package)
    {
        Id = package.Package.Id;
        Name = package.Package.Name;
    }
}