using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class AnotherOptionServices : IAnotherOptionServices
{
    private readonly IAnotherOptionRepository _anotherOptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AnotherOptionServices(IRepositoryManager repositoryManager)
    {
        _anotherOptionRepository = repositoryManager.AnotherOptionRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<AnotherOptionReadDto>> FindAnotherOptionsAsync()
    {
        var anotherOptions = await _anotherOptionRepository.FindAllAsync();
        return anotherOptions.Select(o => new AnotherOptionReadDto(o)).ToList();
    }

    public async Task<AnotherOptionReadDto> FindAnotherOptionAsync(long id)
    {
        var anotherOption = await _anotherOptionRepository.FindByIdAsync(id);
        return new AnotherOptionReadDto(anotherOption);
    }

    public async Task<long> CreateAnotherOptionAsync(AnotherOptionWriteDto anotherOptionWriteDto)
    {
        var anotherOption = await _anotherOptionRepository.CreateAsync(anotherOptionWriteDto.ToAnotherOption());
        await _unitOfWork.SaveChangesAsync();
        return anotherOption.Id;
    }

    public async Task UpdateAnotherOptionAsync(long id, AnotherOptionWriteDto anotherOptionWriteDto)
    {
        var anotherOption = await _anotherOptionRepository.FindByIdAsync(id);
        anotherOption.Name = anotherOptionWriteDto.Name;
        await _anotherOptionRepository.UpdateAsync(anotherOption);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAnotherOptionAsync(long id)
    {
        var anotherOption = await _anotherOptionRepository.FindByIdAsync(id);
        if (anotherOption == null)
        {
            throw new NullReferenceException();
        }
        await _anotherOptionRepository.DeleteAsync(anotherOption);
        await _unitOfWork.SaveChangesAsync();
    }
}