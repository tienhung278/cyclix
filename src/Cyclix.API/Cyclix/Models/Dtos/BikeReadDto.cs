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
        PackageId = Array.ConvertAll(bike.PackageId.Split(','), s =>
        {
            s = string.IsNullOrEmpty(s) ? "0" : s;   
            return long.Parse(s);
        });
        OptionId = Array.ConvertAll(bike.OptionId.Split(','), s =>
        {
            s = string.IsNullOrEmpty(s) ? "0" : s;   
            return long.Parse(s);
        });
        AnotherOptionId = Array.ConvertAll(bike.AnotherOptionId.Split(','), s =>
        {
            s = string.IsNullOrEmpty(s) ? "0" : s;   
            return long.Parse(s);
        });
        Description = bike.Description;
        Note = bike.Note;
        Customer = new CustomerReadDto(bike.Customer);
    }
}