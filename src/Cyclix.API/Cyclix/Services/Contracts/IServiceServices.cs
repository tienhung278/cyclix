using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IServiceServices
{
    Task<IReadOnlyList<ServiceReadDto>> FindServicesAsync();
    Task<ServiceReadDto> FindServiceAsync(long id);
    Task<long> CreateServiceAsync(ServiceWriteDto serviceWriteDto);
    Task UpdateServiceAsync(long id, ServiceWriteDto serviceWriteDto);
    Task DeleteServiceAsync(long id);
}