using Cyclix.Entities.Common;

namespace Cyclix.Entities;

public class Option : EntityBase
{
    public string Name { get; set; }
    public ICollection<RequestOption> RequestOptions { get; set; }
}