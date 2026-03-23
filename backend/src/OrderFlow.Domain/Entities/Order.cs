using OrderFlow.Domain.Enums;

namespace OrderFlow.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string CustomerName { get; private set; } = string.Empty;
    public string CustomerEmail { get; private set; } = string.Empty;
    public OrderStatus Status { get; private set; } = OrderStatus.Created;
    public decimal TotalAmount { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public List<OrderItem> Items { get; private set; } = new();

    private Order() { }

    public Order(string customerName, string customerEmail)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("O nome do cliente é obrigatório.");

        if (string.IsNullOrWhiteSpace(customerEmail))
            throw new ArgumentException("O email do cliente é obrigatório.");

        CustomerName = customerName;
        CustomerEmail = customerEmail;
        Status = OrderStatus.Created;
    }

    public void AddItem(OrderItem item)
    {
        if (Status == OrderStatus.Cancelled || Status == OrderStatus.Shipped)
            throw new InvalidOperationException("Não é possível adicionar itens a um pedido finalizado.");

        Items.Add(item);
        RecalculateTotal();
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsPaid()
    {
        if (Status != OrderStatus.Created)
            throw new InvalidOperationException("Somente pedidos criados podem ser pagos.");

        Status = OrderStatus.Paid;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsShipped()
    {
        if (Status != OrderStatus.Paid)
            throw new InvalidOperationException("Somente pedidos pagos podem ser enviados.");

        Status = OrderStatus.Shipped;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
            throw new InvalidOperationException("Não é possível cancelar um pedido já enviado.");

        if (Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Pedido já está cancelado.");

        Status = OrderStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }

    private void RecalculateTotal()
    {
        TotalAmount = Items.Sum(i => i.Subtotal);
    }
}