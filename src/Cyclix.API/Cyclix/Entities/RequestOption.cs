namespace Cyclix.Entities;

public class RequestOption
{
    public long RequestId { get; set; }
    public Request Request { get; set; }
    public long OptionId { get; set; }
    public Option Option { get; set; }
}