using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IPackageServices
{
    Task<IReadOnlyList<PackageReadDto>> FindPackagesAsync();
    Task<PackageReadDto> FindPackageAsync(long id);
    Task<long> CreatePackageAsync(PackageWriteDto packageWriteDto);
    Task UpdatePackageAsync(long id, PackageWriteDto packageWriteDto);
    Task DeletePackageAsync(long id);
}