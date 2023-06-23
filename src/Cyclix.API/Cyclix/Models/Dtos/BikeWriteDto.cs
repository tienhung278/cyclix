using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class BikeWriteDto
{
    public long TypeId { get; set; }
    public long BrandId { get; set; }
    public long ServiceId { get; set; }
    public long[] PackageId { get; set; }
    public long[] OptionId { get; set; }
    public long[] AnotherOptionId { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public CustomerWriteDto Customer { get; set; }

    public Bike ToBike()
    {
        return new Bike
        {
            TypeId = TypeId,
            BrandId = BrandId,
            ServiceId = ServiceId,
            BikePackages = PackageId.Select(p => new BikePackage { PackageId = p }).ToArray(),
            BikeOptions = OptionId.Select(o => new BikeOption { OptionId = o }).ToArray(),
            BikeAnotherOptions = AnotherOptionId.Select(ao => new BikeAnotherOption { AnotherOptionId = ao }).ToArray(),
            Description = Description,
            Note = Note,
            Customer = Customer.ToCustomer()
        };
    }
}