using Cyclix.Entities;

namespace Cyclix.Repository;

public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
{
    public BrandRepository(RepositoryContext context) : base(context)
    {
        
    }
}