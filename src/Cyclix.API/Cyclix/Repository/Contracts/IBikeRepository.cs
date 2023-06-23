using Cyclix.Entities;

namespace Cyclix.Repository;

public interface IBikeRepository : IRepositoryBase<Bike>
{
    Bike GetBike();
    void CreateBike(Bike bike);
}