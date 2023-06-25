using Cyclix.Entities.Common;

namespace Cyclix.Entities;

public class Package : EntityBase
{
    public string Name { get; set; }
    public ICollection<RequestPackage> RequestPackages { get; set; }
}