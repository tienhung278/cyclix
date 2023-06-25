namespace Cyclix.Repository;

public interface IRepositoryManager
{
    public ITypeRepository TypeRepository { get; }
    public IBrandRepository BrandRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    public IPackageRepository PackageRepository { get; }
    public IOptionRepository OptionRepository { get; }
    public IAnotherOptionRepository AnotherOptionRepository { get; }
    public IRequestPackageRepository RequestPackageRepository { get; }
    public IRequestOptionRepository RequestOptionRepository { get; }
    public IRequestAnotherOptionRepository RequestAnotherOptionRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public IRequestRepository RequestRepository { get; }
    public IUnitOfWork UnitOfWork { get; }
}