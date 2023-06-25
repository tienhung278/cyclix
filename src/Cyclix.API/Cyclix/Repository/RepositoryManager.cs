namespace Cyclix.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<ITypeRepository> _lazyTypeRepository;
    private readonly Lazy<IBrandRepository> _lazyBrandRepository;
    private readonly Lazy<IServiceRepository> _lazyServiceRepository;
    private readonly Lazy<IPackageRepository> _lazyPackageRepository;
    private readonly Lazy<IOptionRepository> _lazyOptionRepository;
    private readonly Lazy<IAnotherOptionRepository> _lazyAnotherOptionRepository;
    private readonly Lazy<IRequestPackageRepository> _lazyRequestPackageRepository;
    private readonly Lazy<IRequestOptionRepository> _lazyRequestOptionRepository;
    private readonly Lazy<IRequestAnotherOptionRepository> _lazyRequestAnotherOptionRepository;
    private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;
    private readonly Lazy<IRequestRepository> _lazyRequestRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWorkRepository;

    public ITypeRepository TypeRepository => _lazyTypeRepository.Value;
    public IBrandRepository BrandRepository => _lazyBrandRepository.Value;
    public IServiceRepository ServiceRepository => _lazyServiceRepository.Value;
    public IPackageRepository PackageRepository => _lazyPackageRepository.Value;
    public IOptionRepository OptionRepository => _lazyOptionRepository.Value;
    public IAnotherOptionRepository AnotherOptionRepository => _lazyAnotherOptionRepository.Value;
    public IRequestPackageRepository RequestPackageRepository => _lazyRequestPackageRepository.Value;
    public IRequestOptionRepository RequestOptionRepository => _lazyRequestOptionRepository.Value;
    public IRequestAnotherOptionRepository RequestAnotherOptionRepository => _lazyRequestAnotherOptionRepository.Value;
    public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
    public IRequestRepository RequestRepository => _lazyRequestRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWorkRepository.Value;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _lazyTypeRepository = new Lazy<ITypeRepository>(() => new TypeRepository(context));
        _lazyBrandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(context));
        _lazyServiceRepository = new Lazy<IServiceRepository>(() => new ServiceRepository(context));
        _lazyPackageRepository = new Lazy<IPackageRepository>(() => new PackageRepository(context));
        _lazyOptionRepository = new Lazy<IOptionRepository>(() => new OptionRepository(context));
        _lazyAnotherOptionRepository = new Lazy<IAnotherOptionRepository>(() => new AnotherOptionRepository(context));
        _lazyRequestPackageRepository = new Lazy<IRequestPackageRepository>(() => new RequestPackageRepository(context));
        _lazyRequestOptionRepository = new Lazy<IRequestOptionRepository>(() => new RequestOptionRepository(context));
        _lazyRequestAnotherOptionRepository = new Lazy<IRequestAnotherOptionRepository>(() => new RequestAnotherOptionRepository(context));
        _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
        _lazyRequestRepository = new Lazy<IRequestRepository>(() => new RequestRepository(context));
        _lazyUnitOfWorkRepository = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
    }
}