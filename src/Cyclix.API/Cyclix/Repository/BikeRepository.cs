using Cyclix.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cyclix.Repository;

public class BikeRepository : RepositoryBase<Bike>, IBikeRepository
{
    private readonly RepositoryContext _context;

    public BikeRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Bike>> GetBikes()
    {
        return await _context.Set<Bike>()
            .Include(b => b.Type)
            .Include(b => b.Brand)
            .Include(b => b.Service)
            .Include(b => b.BikePackages)
            .ThenInclude(b => b.Package)
            .Include(b => b.BikeOptions)
            .ThenInclude(bo => bo.Option)
            .Include(b => b.BikeAnotherOptions)
            .ThenInclude(bao => bao.AnotherOption)
            .Include(b => b.Customer)
            .ToListAsync();
    }

    public async Task<Bike> GetBike(long id)
    {
        return await _context.Set<Bike>()
            .Include(b => b.Type)
            .Include(b => b.Brand)
            .Include(b => b.Service)
            .Include(b => b.BikePackages)
            .ThenInclude(b => b.Package)
            .Include(b => b.BikeOptions)
            .ThenInclude(bo => bo.Option)
            .Include(b => b.BikeAnotherOptions)
            .ThenInclude(bao => bao.AnotherOption)
            .Include(b => b.Customer)
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();
    }
}