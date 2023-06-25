namespace Cyclix.Services.Contracts;

public interface IServiceManager
{
    ITypeServices TypeServices { get; }
    IBrandServices BrandServices { get; }
    IServiceServices ServiceServices { get; }
    IPackageServices PackageServices { get; }
    IOptionServices OptionServices { get; }
    IAnotherOptionServices AnotherOptionServices { get; }
    IRequestServices RequestServices { get; }
} 