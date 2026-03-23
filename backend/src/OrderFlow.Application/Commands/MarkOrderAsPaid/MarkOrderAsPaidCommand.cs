namespace OrderFlow.Application.Commands.MarkOrderAsPaid;

public class MarkOrderAsPaidCommand
{
    public Guid OrderId { get; set; }

    public MarkOrderAsPaidCommand(Guid orderId)
    {
        OrderId = orderId;
    }
}