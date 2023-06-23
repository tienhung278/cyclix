using Cyclix.Entities.Common;

namespace Cyclix.Entities;

public class Bike : EntityBase
{
    public long TypeId { get; set; }
    public long BrandId { get; set; }
    public long ServiceId { get; set; }
    public string PackageId { get; set; }
    public string OptionId { get; set; }
    public string AnotherOptionId { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }

    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
}