namespace Cyclix.Entities;

public class RequestPackage
{
    public long RequestId { get; set; }
    public Request Request { get; set; }
    public long PackageId { get; set; }
    public Package Package { get; set; }
}