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
    private readonly Lazy<IBikePackageRepository> _lazyBikePackageRepository;
    private readonly Lazy<IBikeOptionRepository> _lazyBikeOptionRepository;
    private readonly Lazy<IBikeAnotherOptionRepository> _lazyBikeAnotherOptionRepository;
    private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;
    private readonly Lazy<IBikeRepository> _lazyBikeRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWorkRepository;

    public ITypeRepository TypeRepository => _lazyTypeRepository.Value;
    public IBrandRepository BrandRepository => _lazyBrandRepository.Value;
    public IServiceRepository ServiceRepository => _lazyServiceRepository.Value;
    public IPackageRepository PackageRepository => _lazyPackageRepository.Value;
    public IOptionRepository OptionRepository => _lazyOptionRepository.Value;
    public IAnotherOptionRepository AnotherOptionRepository => _lazyAnotherOptionRepository.Value;
    public IBikePackageRepository BikePackageRepository => _lazyBikePackageRepository.Value;
    public IBikeOptionRepository BikeOptionRepository => _lazyBikeOptionRepository.Value;
    public IBikeAnotherOptionRepository BikeAnotherOptionRepository => _lazyBikeAnotherOptionRepository.Value;
    public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
    public IBikeRepository BikeRepository => _lazyBikeRepository.Value;
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
        _lazyBikePackageRepository = new Lazy<IBikePackageRepository>(() => new BikePackageRepository(context));
        _lazyBikeOptionRepository = new Lazy<IBikeOptionRepository>(() => new BikeOptionRepository(context));
        _lazyBikeAnotherOptionRepository = new Lazy<IBikeAnotherOptionRepository>(() => new BikeAnotherOptionRepository(context));
        _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
        _lazyBikeRepository = new Lazy<IBikeRepository>(() => new BikeRepository(context));
        _lazyUnitOfWorkRepository = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
    }
}