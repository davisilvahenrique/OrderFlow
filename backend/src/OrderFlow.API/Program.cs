using OrderFlow.Application.Commands.CreateOrder;
using OrderFlow.Application.Interfaces;
using OrderFlow.Application.Queries.GetOrderById;
using OrderFlow.Infrastructure.Persistence.Repositories;
using OrderFlow.Application.Commands.AddOrderItem;
using OrderFlow.Application.Commands.CancelOrder;
using OrderFlow.Application.Commands.MarkOrderAsPaid;
using OrderFlow.Application.Commands.MarkOrderAsShipped;
using Microsoft.EntityFrameworkCore;
using OrderFlow.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderFlowDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<CreateOrderCommandHandler>();
builder.Services.AddScoped<GetOrderByIdQueryHandler>();
builder.Services.AddScoped<AddOrderItemCommandHandler>();
builder.Services.AddScoped<MarkOrderAsPaidCommandHandler>();
builder.Services.AddScoped<MarkOrderAsShippedCommandHandler>();
builder.Services.AddScoped<CancelOrderCommandHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();