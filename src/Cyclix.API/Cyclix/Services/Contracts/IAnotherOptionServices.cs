using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IAnotherOptionServices
{
    Task<IReadOnlyList<AnotherOptionReadDto>> FindAnotherOptionsAsync();
    Task<AnotherOptionReadDto> FindAnotherOptionAsync(long id);
    Task<long> CreateAnotherOptionAsync(AnotherOptionWriteDto anotheroptionWriteDto);
    Task UpdateAnotherOptionAsync(long id, AnotherOptionWriteDto anotheroptionWriteDto);
    Task DeleteAnotherOptionAsync(long id);
}