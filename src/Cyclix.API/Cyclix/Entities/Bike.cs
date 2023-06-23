using Cyclix.Entities.Common;

namespace Cyclix.Entities;

public class Bike : EntityBase
{
    public long TypeId { get; set; }
    public Type Type { get; set; }
    public long BrandId { get; set; }
    public Brand Brand { get; set; }
    public long ServiceId { get; set; }
    public Service Service { get; set; }
    public ICollection<BikePackage> BikePackages { get; set; }
    public ICollection<BikeOption> BikeOptions { get; set; }
    public ICollection<BikeAnotherOption> BikeAnotherOptions { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
}