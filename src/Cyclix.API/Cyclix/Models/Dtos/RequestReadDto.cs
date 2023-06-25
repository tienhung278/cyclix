using System.Runtime.InteropServices.JavaScript;
using Cyclix.Entities;

namespace Cyclix.Models.Dtos;

public class RequestReadDto
{
    public long Id { get; set; }
    public TypeReadDto Type { get; set; }
    public BrandReadDto Brand { get; set; }
    public ServiceReadDto Service { get; set; }
    public PackageReadDto[] Packages { get; set; }
    public OptionReadDto[] Options { get; set; }
    public AnotherOptionReadDto[] AnotherOptions { get; set; }
    public string Description { get; set; }
    public string Note { get; set; }
    public CustomerReadDto Customer { get; set; }

    public RequestReadDto(Request request)
    {
        Id = request.Id;
        Type = new TypeReadDto(request.Type);
        Brand = new BrandReadDto(request.Brand);
        Service = new ServiceReadDto(request.Service);
        Packages = request.RequestPackages.Select(bp => new PackageReadDto(bp.Package)).ToArray();
        Options = request.RequestOptions.Select(bo => new OptionReadDto(bo.Option)).ToArray();
        AnotherOptions = request.RequestAnotherOptions.Select(bao => new AnotherOptionReadDto(bao.AnotherOption)).ToArray();
        Description = request.Description;
        Note = request.Note;
        Customer = new CustomerReadDto(request.Customer);
    }
}