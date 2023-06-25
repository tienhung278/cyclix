using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class RequestWriteDto
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

    public Request ToRequest()
    {
        return new Request
        {
            TypeId = TypeId,
            BrandId = BrandId,
            ServiceId = ServiceId,
            RequestPackages = PackageId.Select(p => new RequestPackage { PackageId = p }).ToArray(),
            RequestOptions = OptionId.Select(o => new RequestOption { OptionId = o }).ToArray(),
            RequestAnotherOptions = AnotherOptionId.Select(ao => new RequestAnotherOption { AnotherOptionId = ao }).ToArray(),
            Description = Description,
            Note = Note,
            Customer = Customer.ToCustomer()
        };
    }
}