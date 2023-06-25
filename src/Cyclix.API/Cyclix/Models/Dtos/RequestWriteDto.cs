using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class RequestWriteDto
{
    public long TypeId { get; set; }
    public long BrandId { get; set; }
    public long ServiceId { get; set; }
    public long[] PackageIds { get; set; }
    public long[] OptionIds { get; set; }
    public long[] AnotherOptionIds { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public CustomerWriteDto Customer { get; set; }

    public Request ToRequest()
    {
        return new Request
        {
            TypeId = TypeId,
            BrandId = BrandId,
            ServiceId = ServiceId,
            RequestPackages = PackageIds.Select(p => new RequestPackage { PackageId = p }).ToArray(),
            RequestOptions = OptionIds.Select(o => new RequestOption { OptionId = o }).ToArray(),
            RequestAnotherOptions = AnotherOptionIds.Select(ao => new RequestAnotherOption { AnotherOptionId = ao }).ToArray(),
            Description = Description,
            Note = Note,
            Customer = Customer.ToCustomer()
        };
    }
}