using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IBikeServices
{
    Task<IReadOnlyList<BikeReadDto>> FindBikesAsync();
    Task<BikeReadDto> FindBikeAsync(long id);
    Task<long> CreateBikeAsync(BikeWriteDto bikeWriteDto);
    Task UpdateBikeAsync(long id, BikeWriteDto bikeWriteDto);
    Task DeleteBikeAsync(long id);
}