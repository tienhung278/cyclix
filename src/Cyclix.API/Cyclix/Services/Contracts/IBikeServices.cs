using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IBikeServices
{
    BikeReadDto GetBike();
    void CreateBike(BikeWriteDto bikeWriteDto);
}