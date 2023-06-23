using Cyclix.Entities.Common;

namespace Cyclix.Entities;

public class Item : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}