using OrderFlow.Application.Commands.CreateOrder;
using OrderFlow.Application.Interfaces;
using OrderFlow.Application.Queries.GetOrderById;
using OrderFlow.Infrastructure.Persistence.Repositories;
using OrderFlow.Application.Commands.AddOrderItem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<CreateOrderCommandHandler>();
builder.Services.AddScoped<GetOrderByIdQueryHandler>();
builder.Services.AddScoped<AddOrderItemCommandHandler>();

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