using Cyclix.Entities;

namespace Cyclix.Repository;

public interface IRequestRepository : IRepositoryBase<Request>
{
    Task<IReadOnlyList<Request>> GetRequests();
    Task<Request> GetRequest(long id);
}