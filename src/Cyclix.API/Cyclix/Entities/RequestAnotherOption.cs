namespace Cyclix.Entities;

public class RequestAnotherOption
{
    public long RequestId { get; set; }
    public Request Request { get; set; }
    public long AnotherOptionId { get; set; }
    public AnotherOption AnotherOption { get; set; }
}