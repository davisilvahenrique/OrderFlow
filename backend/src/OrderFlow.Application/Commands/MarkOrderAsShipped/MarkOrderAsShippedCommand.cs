namespace OrderFlow.Application.Commands.MarkOrderAsShipped;

public class MarkOrderAsShippedCommand
{
    public Guid OrderId { get; set; }

    public MarkOrderAsShippedCommand(Guid orderId)
    {
        OrderId = orderId;
    }
}