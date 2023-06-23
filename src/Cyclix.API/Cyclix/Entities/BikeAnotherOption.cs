namespace Cyclix.Entities;

public class BikeAnotherOption
{
    public long BikeId { get; set; }
    public Bike Bike { get; set; }
    public long AnotherOptionId { get; set; }
    public AnotherOption AnotherOption { get; set; }
}