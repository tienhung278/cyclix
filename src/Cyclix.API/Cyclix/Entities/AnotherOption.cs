using Cyclix.Entities.Common;

namespace Cyclix.Entities;

public class AnotherOption : EntityBase
{
    public string Name { get; set; }
    public ICollection<RequestAnotherOption> RequestAnotherOptions { get; set; }
}