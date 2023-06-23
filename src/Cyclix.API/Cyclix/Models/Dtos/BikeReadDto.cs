using System.Runtime.InteropServices.JavaScript;
using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class BikeReadDto
{
    public long Id { get; set; }
    public TypeReadDto Type { get; set; }
    public BrandReadDto Brand { get; set; }
    public ServiceReadDto Service { get; set; }
    public PackageReadDto[] Packages { get; set; }
    public OptionReadDto[] Options { get; set; }
    public AnotherOptionReadDto[] AnotherOptions { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public CustomerReadDto Customer { get; set; }

    public BikeReadDto(Bike bike)
    {
        Id = bike.Id;
        Type = new TypeReadDto(bike.Type);
        Brand = new BrandReadDto(bike.Brand);
        Service = new ServiceReadDto(bike.Service);
        Packages = bike.BikePackages.Select(bp => new PackageReadDto(bp.Package)).ToArray();
        Options = bike.BikeOptions.Select(bo => new OptionReadDto(bo.Option)).ToArray();
        AnotherOptions = bike.BikeAnotherOptions.Select(bao => new AnotherOptionReadDto(bao.AnotherOption)).ToArray();
        Description = bike.Description;
        Note = bike.Note;
        Customer = new CustomerReadDto(bike.Customer);
    }
}