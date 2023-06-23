namespace Cyclix.Entities;

public class BikeOption
{
    public long BikeId { get; set; }
    public Bike Bike { get; set; }
    public long OptionId { get; set; }
    public Option Option { get; set; }
}