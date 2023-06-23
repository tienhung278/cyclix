using Cyclix.Entities;

namespace Cyclix.Repository;

public interface IBikeRepository : IRepositoryBase<Bike>
{
    Task<IReadOnlyList<Bike>> GetBikes();
    Task<Bike> GetBike(long id);
}