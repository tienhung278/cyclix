using Cyclix.Entities;
using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class BikeServices : IBikeServices
{
    private readonly IBikeRepository _bikeRepository;
    private readonly IPackageRepository _packageRepository;
    private readonly IOptionRepository _optionRepository;
    private readonly IAnotherOptionRepository _anotherOptionRepository;
    private readonly IBikePackageRepository _bikePackageRepository;
    private readonly IBikeOptionRepository _bikeOptionRepository;
    private readonly IBikeAnotherOptionRepository _bikeAnotherOptionRepository;

    public BikeServices(IRepositoryManager repositoryManager)
    {
        _bikeRepository = repositoryManager.BikeRepository;
        _packageRepository = repositoryManager.PackageRepository;
        _optionRepository = repositoryManager.OptionRepository;
        _anotherOptionRepository = repositoryManager.AnotherOptionRepository;
        _bikePackageRepository = repositoryManager.BikePackageRepository;
        _bikeOptionRepository = repositoryManager.BikeOptionRepository;
        _bikeAnotherOptionRepository = repositoryManager.BikeAnotherOptionRepository;
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
        var bikePackages = new List<BikePackage>();
        var bike = bikeWriteDto.ToBike();
        bike = await _bikeRepository.CreateAsync(bike);
        
        foreach (var packageId in bikeWriteDto.PackageId)
        {
            var package = await _packageRepository.FindByIdAsync(packageId);
            if (package == null)
            {
                throw new NullReferenceException($"packageId {packageId} was not found");
            }
            bikePackages.Add(new BikePackage { Bike = bike, Package = package });
        }
        
        return bike.Id;
    }

    public async Task UpdateBikeAsync(long id, BikeWriteDto bikeWriteDto)
    {
        await _bikeRepository.UpdateAsync(bikeWriteDto.ToBike());
    }

    public async Task DeleteBikeAsync(long id)
    {
        var bike = await _bikeRepository.FindByIdAsync(id);
        await _bikeRepository.DeleteAsync(bike);
    }
}