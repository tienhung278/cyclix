using Cyclix.Entities;

namespace Cyclix.Repository;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(RepositoryContext context) : base(context)
    {
        
    }
}