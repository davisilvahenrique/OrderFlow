namespace OrderFlow.Application.Commands.CancelOrder;

public class CancelOrderCommand
{
    public Guid OrderId { get; set; }

    public CancelOrderCommand(Guid orderId)
    {
        OrderId = orderId;
    }
}