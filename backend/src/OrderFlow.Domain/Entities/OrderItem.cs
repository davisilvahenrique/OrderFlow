namespace OrderFlow.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrderId { get; private set; }

    public string ProductName { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public decimal Subtotal => Quantity * UnitPrice;

    private OrderItem() { }

    public OrderItem(string productName, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("O nome do produto é obrigatório.");

        if (quantity <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        if (unitPrice <= 0)
            throw new ArgumentException("O preço unitário deve ser maior que zero.");

        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}