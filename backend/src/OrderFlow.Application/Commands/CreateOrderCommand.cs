namespace OrderFlow.Application.Commands.CreateOrder;

public class CreateOrderCommand
{
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
}