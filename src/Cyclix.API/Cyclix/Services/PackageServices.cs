using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class PackageServices : IPackageServices
{
    private readonly IPackageRepository _packageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PackageServices(IRepositoryManager repositoryManager)
    {
        _packageRepository = repositoryManager.PackageRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<PackageReadDto>> FindPackagesAsync()
    {
        var packages = await _packageRepository.FindAllAsync();
        return packages.Select(p => new PackageReadDto(p)).ToList();
    }

    public async Task<PackageReadDto> FindPackageAsync(long id)
    {
        var package = await _packageRepository.FindByIdAsync(id);
        return new PackageReadDto(package);
    }

    public async Task<long> CreatePackageAsync(PackageWriteDto packageWriteDto)
    {
        var package = await _packageRepository.CreateAsync(packageWriteDto.ToPackage());
        await _unitOfWork.SaveChangesAsync();
        return package.Id;
    }

    public async Task UpdatePackageAsync(long id, PackageWriteDto packageWriteDto)
    {
        var package = await _packageRepository.FindByIdAsync(id);
        package.Name = packageWriteDto.Name;
        await _packageRepository.UpdateAsync(package);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeletePackageAsync(long id)
    {
        var package = await _packageRepository.FindByIdAsync(id);
        if (package == null)
        {
            throw new NullReferenceException();
        }
        await _packageRepository.DeleteAsync(package);
        await _unitOfWork.SaveChangesAsync();
    }
}