using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class BrandServices : IBrandServices
{
    private readonly IBrandRepository _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BrandServices(IRepositoryManager repositoryManager)
    {
        _brandRepository = repositoryManager.BrandRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<BrandReadDto>> FindBrandsAsync()
    {
        var brands = await _brandRepository.FindAllAsync();
        return brands.Select(b => new BrandReadDto(b)).ToList();
    }

    public async Task<BrandReadDto> FindBrandAsync(long id)
    {
        var brand = await _brandRepository.FindByIdAsync(id);
        return new BrandReadDto(brand);
    }

    public async Task<long> CreateBrandAsync(BrandWriteDto brandWriteDto)
    {
        var brand = await _brandRepository.CreateAsync(brandWriteDto.ToBrand());
        await _unitOfWork.SaveChangesAsync();
        return brand.Id;
    }

    public async Task UpdateBrandAsync(long id, BrandWriteDto brandWriteDto)
    {
        var brand = await _brandRepository.FindByIdAsync(id);
        brand.Name = brandWriteDto.Name;
        await _brandRepository.UpdateAsync(brand);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteBrandAsync(long id)
    {
        var brand = await _brandRepository.FindByIdAsync(id);
        if (brand == null)
        {
            throw new NullReferenceException();
        }
        await _brandRepository.DeleteAsync(brand);
        await _unitOfWork.SaveChangesAsync();
    }
}