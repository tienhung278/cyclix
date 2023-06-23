using Cyclix.Entities;
using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class BikeServices : IBikeServices
{
    private readonly IBikeRepository _bikeRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IPackageRepository _packageRepository;
    private readonly IOptionRepository _optionRepository;
    private readonly IAnotherOptionRepository _anotherOptionRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BikeServices(IRepositoryManager repositoryManager)
    {
        _bikeRepository = repositoryManager.BikeRepository;
        _typeRepository = repositoryManager.TypeRepository;
        _brandRepository = repositoryManager.BrandRepository;
        _serviceRepository = repositoryManager.ServiceRepository;
        _packageRepository = repositoryManager.PackageRepository;
        _optionRepository = repositoryManager.OptionRepository;
        _anotherOptionRepository = repositoryManager.AnotherOptionRepository;
        _customerRepository = repositoryManager.CustomerRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<BikeReadDto>> FindBikesAsync()
    {
        var bikes = await _bikeRepository.GetBikes();
        return bikes.Select(b => new BikeReadDto(b)).ToList();
    }

    public async Task<BikeReadDto> FindBikeAsync(long id)
    {
        var bike = await _bikeRepository.GetBike(id);
        return new BikeReadDto(bike);
    }

    public async Task<long> CreateBikeAsync(BikeWriteDto bikeWriteDto)
    {
        var bike = bikeWriteDto.ToBike();
        
        bike.BikePackages = new List<BikePackage>();
        foreach (var packageId in bikeWriteDto.PackageId)
        {
            var package = await _packageRepository.FindByIdAsync(packageId);
            if (package == null)
            {
                throw new NullReferenceException($"packageId {packageId} was not found");
            }
            bike.BikePackages.Add(new BikePackage { Bike = bike, Package = package });
        }
        
        bike.BikeOptions = new List<BikeOption>();
        foreach (var optionId in bikeWriteDto.OptionId)
        {
            var option = await _optionRepository.FindByIdAsync(optionId);
            if (option == null)
            {
                throw new NullReferenceException($"optionId {optionId} was not found");
            }
            bike.BikeOptions.Add(new BikeOption { Bike = bike, Option = option });
        }
        
        bike.BikeAnotherOptions = new List<BikeAnotherOption>();
        foreach (var anotherOptionId in bikeWriteDto.AnotherOptionId)
        {
            var anotherOption = await _anotherOptionRepository.FindByIdAsync(anotherOptionId);
            if (anotherOption == null)
            {
                throw new NullReferenceException($"anotherOptionId {anotherOptionId} was not found");
            }
            bike.BikeAnotherOptions.Add(new BikeAnotherOption { Bike = bike, AnotherOption = anotherOption });
        }
        
        bike = await _bikeRepository.CreateAsync(bike);

        await _unitOfWork.SaveChangesAsync();
        
        return bike.Id;
    }

    public async Task UpdateBikeAsync(long id, BikeWriteDto bikeWriteDto)
    {
        var bike = await _bikeRepository.GetBike(id);
        
        var type = await _typeRepository.FindByIdAsync(bikeWriteDto.TypeId);
        if (type == null)
        {
            throw new NullReferenceException($"typeId {bikeWriteDto.TypeId} was not found");
        }
        bike.TypeId = bikeWriteDto.TypeId;
        
        var brand = await _brandRepository.FindByIdAsync(bikeWriteDto.BrandId);
        if (brand == null)
        {
            throw new NullReferenceException($"brandId {bikeWriteDto.BrandId} was not found");
        }
        bike.BrandId = bikeWriteDto.BrandId;
        
        var service = await _serviceRepository.FindByIdAsync(bikeWriteDto.ServiceId);
        if (service == null)
        {
            throw new NullReferenceException($"serviceId {bikeWriteDto.ServiceId} was not found");
        }
        bike.ServiceId = bikeWriteDto.ServiceId;
        
        
        bike.Customer = bikeWriteDto.Customer.ToCustomer();
        bike.Description = bikeWriteDto.Description;
        bike.Note = bikeWriteDto.Note;

        bike.BikePackages = new List<BikePackage>();
        foreach (var packageId in bikeWriteDto.PackageId)
        {
            var package = await _packageRepository.FindByIdAsync(packageId);
            if (package == null)
            {
                throw new NullReferenceException($"packageId {packageId} was not found");
            }
            bike.BikePackages.Add(new BikePackage { BikeId = bike.Id, PackageId = packageId });
        }
        
        bike.BikeOptions = new List<BikeOption>();
        foreach (var optionId in bikeWriteDto.OptionId)
        {
            var option = await _optionRepository.FindByIdAsync(optionId);
            if (option == null)
            {
                throw new NullReferenceException($"optionId {optionId} was not found");
            }
            bike.BikeOptions.Add(new BikeOption { BikeId = bike.Id, OptionId = optionId });
        }
        
        bike.BikeAnotherOptions = new List<BikeAnotherOption>();
        foreach (var anotherOptionId in bikeWriteDto.AnotherOptionId)
        {
            var anotherOption = await _anotherOptionRepository.FindByIdAsync(anotherOptionId);
            if (anotherOption == null)
            {
                throw new NullReferenceException($"anotherOptionId {anotherOptionId} was not found");
            }
            bike.BikeAnotherOptions.Add(new BikeAnotherOption { BikeId = bike.Id, AnotherOptionId = anotherOptionId });
        }
        
        await _bikeRepository.UpdateAsync(bike);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteBikeAsync(long id)
    {
        var bike = await _bikeRepository.FindByIdAsync(id);
        await _bikeRepository.DeleteAsync(bike);
        await _unitOfWork.SaveChangesAsync();
    }
}