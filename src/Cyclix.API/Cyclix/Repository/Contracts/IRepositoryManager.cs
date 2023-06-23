namespace Cyclix.Repository;

public interface IRepositoryManager
{
    public ITypeRepository TypeRepository { get; }
    public IBrandRepository BrandRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    public IPackageRepository PackageRepository { get; }
    public IOptionRepository OptionRepository { get; }
    public IAnotherOptionRepository AnotherOptionRepository { get; }
    public IBikePackageRepository BikePackageRepository { get; }
    public IBikeOptionRepository BikeOptionRepository { get; }
    public IBikeAnotherOptionRepository BikeAnotherOptionRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public IBikeRepository BikeRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
}