using OrderFlow.Application.Interfaces;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private static readonly List<Order> Orders = new();

    public Task AddAsync(Order order, CancellationToken cancellationToken = default)
    {
        Orders.Add(order);
        return Task.CompletedTask;
    }

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        return Task.FromResult(order);
    }

    public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Orders.ToList());
    }

    public Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}