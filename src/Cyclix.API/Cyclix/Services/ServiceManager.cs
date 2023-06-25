using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly Lazy<ITypeServices> _lazyTypeServices;
    private readonly Lazy<IBrandServices> _lazyBrandServices;
    private readonly Lazy<IServiceServices> _lazyServiceServices;
    private readonly Lazy<IPackageServices> _lazyPackageServices;
    private readonly Lazy<IOptionServices> _lazyOptionServices;
    private readonly Lazy<IAnotherOptionServices> _lazyAnotherOptionServices;
    private readonly Lazy<IRequestServices> _lazyRequestServices;

    public ITypeServices TypeServices => _lazyTypeServices.Value;
    public IBrandServices BrandServices => _lazyBrandServices.Value;
    public IServiceServices ServiceServices => _lazyServiceServices.Value;
    public IPackageServices PackageServices => _lazyPackageServices.Value;
    public IOptionServices OptionServices => _lazyOptionServices.Value;
    public IAnotherOptionServices AnotherOptionServices => _lazyAnotherOptionServices.Value;
    public IRequestServices RequestServices => _lazyRequestServices.Value;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _lazyTypeServices = new Lazy<ITypeServices>(() => new TypeServices(_repositoryManager));
        _lazyBrandServices = new Lazy<IBrandServices>(() => new BrandServices(_repositoryManager));
        _lazyServiceServices = new Lazy<IServiceServices>(() => new ServiceServices(_repositoryManager));
        _lazyPackageServices = new Lazy<IPackageServices>(() => new PackageServices(_repositoryManager));
        _lazyOptionServices = new Lazy<IOptionServices>(() => new OptionServices(_repositoryManager));
        _lazyAnotherOptionServices = new Lazy<IAnotherOptionServices>(() => new AnotherOptionServices(_repositoryManager));
        _lazyRequestServices = new Lazy<IRequestServices>(() => new RequestServices(_repositoryManager));
    }
}