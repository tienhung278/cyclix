using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class BikeServices : IBikeServices
{
    private readonly IBikeRepository _bikeRepository;

    public BikeServices(IBikeRepository bikeRepository)
    {
        _bikeRepository = bikeRepository;
    }

    public BikeReadDto GetBike()
    {
        var bike = _bikeRepository.GetBike();
        return new BikeReadDto(bike);
    }

    public void CreateBike(BikeWriteDto bikeWriteDto)
    {
        _bikeRepository.CreateBike(bikeWriteDto.ToBike());
    }
}