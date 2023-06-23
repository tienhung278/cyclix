using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IBrandServices
{
    Task<IReadOnlyList<BrandReadDto>> FindBrandsAsync();
    Task<BrandReadDto> FindBrandAsync(long id);
    Task<long> CreateBrandAsync(BrandWriteDto brandWriteDto);
    Task UpdateBrandAsync(long id, BrandWriteDto brandWriteDto);
    Task DeleteBrandAsync(long id);
}