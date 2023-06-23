using System.Runtime.InteropServices.JavaScript;
using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class BikeReadDto
{
    public long Id { get; set; }
    public long TypeId { get; set; }
    public long BrandId { get; set; }
    public long ServiceId { get; set; }
    public long[] PackageId { get; set; }
    public long[] OptionId { get; set; }
    public long[] AnotherOptionId { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public CustomerReadDto Customer { get; set; }

    public BikeReadDto(Bike bike)
    {
        Id = bike.Id;
        TypeId = bike.TypeId;
        BrandId = bike.BrandId;
        ServiceId = bike.ServiceId;
        PackageId = bike.BikePackages.Select(bp => bp.PackageId).ToArray();
        OptionId = bike.BikeOptions.Select(bo => bo.OptionId).ToArray();
        AnotherOptionId = bike.BikeAnotherOptions.Select(bao => bao.AnotherOptionId).ToArray();
        Description = bike.Description;
        Note = bike.Note;
        Customer = new CustomerReadDto(bike.Customer);
    }
}