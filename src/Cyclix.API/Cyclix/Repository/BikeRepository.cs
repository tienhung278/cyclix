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

    public Bike GetBike()
    {
        return FindAll()
            .Include(b => b.Customer)
            .OrderByDescending(b => b.Id)
            .FirstOrDefault();
    }

    public void CreateBike(Bike bike)
    {
        Add(bike);
        Save();
    }
    
    private void Save()
    {
        _context.SaveChanges();
    }
}