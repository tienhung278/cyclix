using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IOptionServices
{
    Task<IReadOnlyList<OptionReadDto>> FindOptionsAsync();
    Task<OptionReadDto> FindOptionAsync(long id);
    Task<long> CreateOptionAsync(OptionWriteDto optionWriteDto);
    Task UpdateOptionAsync(long id, OptionWriteDto optionWriteDto);
    Task DeleteOptionAsync(long id);
}