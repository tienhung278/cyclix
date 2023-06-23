using Cyclix.Models.Dtos;
using Cyclix.Repository;
using Cyclix.Services.Contracts;

namespace Cyclix.Services;

public class OptionServices : IOptionServices
{
    private readonly IOptionRepository _optionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OptionServices(IRepositoryManager repositoryManager)
    {
        _optionRepository = repositoryManager.OptionRepository;
        _unitOfWork = repositoryManager.UnitOfWork;
    }

    public async Task<IReadOnlyList<OptionReadDto>> FindOptionsAsync()
    {
        var options = await _optionRepository.FindAllAsync();
        return options.Select(o => new OptionReadDto(o)).ToList();
    }

    public async Task<OptionReadDto> FindOptionAsync(long id)
    {
        var option = await _optionRepository.FindByIdAsync(id);
        return new OptionReadDto(option);
    }

    public async Task<long> CreateOptionAsync(OptionWriteDto optionWriteDto)
    {
        var option = await _optionRepository.CreateAsync(optionWriteDto.ToOption());
        await _unitOfWork.SaveChangesAsync();
        return option.Id;
    }

    public async Task UpdateOptionAsync(long id, OptionWriteDto optionWriteDto)
    {
        var option = await _optionRepository.FindByIdAsync(id);
        option.Name = optionWriteDto.Name;
        await _optionRepository.UpdateAsync(option);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteOptionAsync(long id)
    {
        var option = await _optionRepository.FindByIdAsync(id);
        if (option == null)
        {
            throw new NullReferenceException();
        }
        await _optionRepository.DeleteAsync(option);
        await _unitOfWork.SaveChangesAsync();
    }
}