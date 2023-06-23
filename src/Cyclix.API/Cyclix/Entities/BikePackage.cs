namespace Cyclix.Entities;

public class BikePackage
{
    public long BikeId { get; set; }
    public Bike Bike { get; set; }
    public long PackageId { get; set; }
    public Package Package { get; set; }
}