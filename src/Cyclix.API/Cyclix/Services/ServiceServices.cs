using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class ServiceServices : IServiceServices
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceServices(IRepositoryManager repositoryManager)
    {
        _serviceRepository = repositoryManager.ServiceRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<ServiceReadDto>> FindServicesAsync()
    {
        var services = await _serviceRepository.FindAllAsync();
        return services.Select(s => new ServiceReadDto(s)).ToList();
    }

    public async Task<ServiceReadDto> FindServiceAsync(long id)
    {
        var service = await _serviceRepository.FindByIdAsync(id);
        return new ServiceReadDto(service);
    }

    public async Task<long> CreateServiceAsync(ServiceWriteDto serviceWriteDto)
    {
        var service = await _serviceRepository.CreateAsync(serviceWriteDto.ToService());
        await _unitOfWork.SaveChangesAsync();
        return service.Id;
    }

    public async Task UpdateServiceAsync(long id, ServiceWriteDto serviceWriteDto)
    {
        var service = await _serviceRepository.FindByIdAsync(id);
        service.Name = serviceWriteDto.Name;
        await _serviceRepository.UpdateAsync(service);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(long id)
    {
        var service = await _serviceRepository.FindByIdAsync(id);
        if (service == null)
        {
            throw new NullReferenceException();
        }
        await _serviceRepository.DeleteAsync(service);
        await _unitOfWork.SaveChangesAsync();
    }
}