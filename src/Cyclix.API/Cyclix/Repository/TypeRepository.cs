namespace Cyclix.Repository;

public class TypeRepository : RepositoryBase<Entities.Type>, ITypeRepository
{
    public TypeRepository(RepositoryContext context) : base(context)
    {
        
    }
}