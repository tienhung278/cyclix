using Cyclix.Entities;
using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class RequestServices : IRequestServices
{
    private readonly IRequestRepository _requestRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IPackageRepository _packageRepository;
    private readonly IOptionRepository _optionRepository;
    private readonly IAnotherOptionRepository _anotherOptionRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RequestServices(IRepositoryManager repositoryManager)
    {
        _requestRepository = repositoryManager.RequestRepository;
        _typeRepository = repositoryManager.TypeRepository;
        _brandRepository = repositoryManager.BrandRepository;
        _serviceRepository = repositoryManager.ServiceRepository;
        _packageRepository = repositoryManager.PackageRepository;
        _optionRepository = repositoryManager.OptionRepository;
        _anotherOptionRepository = repositoryManager.AnotherOptionRepository;
        _customerRepository = repositoryManager.CustomerRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<RequestReadDto>> FindRequestsAsync()
    {
        var requests = await _requestRepository.GetRequests();
        return requests.Select(b => new RequestReadDto(b)).ToList();
    }

    public async Task<RequestReadDto> FindRequestAsync(long id)
    {
        var request = await _requestRepository.GetRequest(id);
        return new RequestReadDto(request);
    }

    public async Task<long> CreateRequestAsync(RequestWriteDto requestWriteDto)
    {
        var request = requestWriteDto.ToRequest();
        
        request.RequestPackages = new List<RequestPackage>();
        foreach (var packageId in requestWriteDto.PackageId)
        {
            var package = await _packageRepository.FindByIdAsync(packageId);
            if (package == null)
            {
                throw new NullReferenceException($"packageId {packageId} was not found");
            }
            request.RequestPackages.Add(new RequestPackage { Request = request, Package = package });
        }
        
        request.RequestOptions = new List<RequestOption>();
        foreach (var optionId in requestWriteDto.OptionId)
        {
            var option = await _optionRepository.FindByIdAsync(optionId);
            if (option == null)
            {
                throw new NullReferenceException($"optionId {optionId} was not found");
            }
            request.RequestOptions.Add(new RequestOption { Request = request, Option = option });
        }
        
        request.RequestAnotherOptions = new List<RequestAnotherOption>();
        foreach (var anotherOptionId in requestWriteDto.AnotherOptionId)
        {
            var anotherOption = await _anotherOptionRepository.FindByIdAsync(anotherOptionId);
            if (anotherOption == null)
            {
                throw new NullReferenceException($"anotherOptionId {anotherOptionId} was not found");
            }
            request.RequestAnotherOptions.Add(new RequestAnotherOption { Request = request, AnotherOption = anotherOption });
        }
        
        request = await _requestRepository.CreateAsync(request);

        await _unitOfWork.SaveChangesAsync();
        
        return request.Id;
    }

    public async Task UpdateRequestAsync(long id, RequestWriteDto requestWriteDto)
    {
        var request = await _requestRepository.GetRequest(id);
        
        var type = await _typeRepository.FindByIdAsync(requestWriteDto.TypeId);
        if (type == null)
        {
            throw new NullReferenceException($"typeId {requestWriteDto.TypeId} was not found");
        }
        request.TypeId = requestWriteDto.TypeId;
        
        var brand = await _brandRepository.FindByIdAsync(requestWriteDto.BrandId);
        if (brand == null)
        {
            throw new NullReferenceException($"brandId {requestWriteDto.BrandId} was not found");
        }
        request.BrandId = requestWriteDto.BrandId;
        
        var service = await _serviceRepository.FindByIdAsync(requestWriteDto.ServiceId);
        if (service == null)
        {
            throw new NullReferenceException($"serviceId {requestWriteDto.ServiceId} was not found");
        }
        request.ServiceId = requestWriteDto.ServiceId;
        
        
        request.Customer = requestWriteDto.Customer.ToCustomer();
        request.Description = requestWriteDto.Description;
        request.Note = requestWriteDto.Note;

        request.RequestPackages = new List<RequestPackage>();
        foreach (var packageId in requestWriteDto.PackageId)
        {
            var package = await _packageRepository.FindByIdAsync(packageId);
            if (package == null)
            {
                throw new NullReferenceException($"packageId {packageId} was not found");
            }
            request.RequestPackages.Add(new RequestPackage { RequestId = request.Id, PackageId = packageId });
        }
        
        request.RequestOptions = new List<RequestOption>();
        foreach (var optionId in requestWriteDto.OptionId)
        {
            var option = await _optionRepository.FindByIdAsync(optionId);
            if (option == null)
            {
                throw new NullReferenceException($"optionId {optionId} was not found");
            }
            request.RequestOptions.Add(new RequestOption { RequestId = request.Id, OptionId = optionId });
        }
        
        request.RequestAnotherOptions = new List<RequestAnotherOption>();
        foreach (var anotherOptionId in requestWriteDto.AnotherOptionId)
        {
            var anotherOption = await _anotherOptionRepository.FindByIdAsync(anotherOptionId);
            if (anotherOption == null)
            {
                throw new NullReferenceException($"anotherOptionId {anotherOptionId} was not found");
            }
            request.RequestAnotherOptions.Add(new RequestAnotherOption { RequestId = request.Id, AnotherOptionId = anotherOptionId });
        }
        
        await _requestRepository.UpdateAsync(request);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteRequestAsync(long id)
    {
        var request = await _requestRepository.FindByIdAsync(id);
        await _requestRepository.DeleteAsync(request);
        await _unitOfWork.SaveChangesAsync();
    }
}