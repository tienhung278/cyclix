using Cyclix.Models.Dtos;

namespace Cyclix.Services.Contracts;

public interface IRequestServices
{
    Task<IReadOnlyList<RequestReadDto>> FindRequestsAsync();
    Task<RequestReadDto> FindRequestAsync(long id);
    Task<RequestReadDto> FindLatestRequestAsync();
    Task<long> CreateRequestAsync(RequestWriteDto requestWriteDto);
    Task UpdateRequestAsync(long id, RequestWriteDto requestWriteDto);
    Task DeleteRequestAsync(long id);
}