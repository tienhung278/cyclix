using Cyclix.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cyclix.Repository;

public class RequestRepository : RepositoryBase<Request>, IRequestRepository
{
    private readonly RepositoryContext _context;

    public RequestRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Request>> GetRequests()
    {
        return await _context.Set<Request>()
            .Include(b => b.Type)
            .Include(b => b.Brand)
            .Include(b => b.Service)
            .Include(b => b.RequestPackages)
            .ThenInclude(b => b.Package)
            .Include(b => b.RequestOptions)
            .ThenInclude(bo => bo.Option)
            .Include(b => b.RequestAnotherOptions)
            .ThenInclude(bao => bao.AnotherOption)
            .Include(b => b.Customer)
            .ToListAsync();
    }

    public async Task<Request> GetRequest(long id)
    {
        return await _context.Set<Request>()
            .Include(b => b.Type)
            .Include(b => b.Brand)
            .Include(b => b.Service)
            .Include(b => b.RequestPackages)
            .ThenInclude(b => b.Package)
            .Include(b => b.RequestOptions)
            .ThenInclude(bo => bo.Option)
            .Include(b => b.RequestAnotherOptions)
            .ThenInclude(bao => bao.AnotherOption)
            .Include(b => b.Customer)
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();
    }
}