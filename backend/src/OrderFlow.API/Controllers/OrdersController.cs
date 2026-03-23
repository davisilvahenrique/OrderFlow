using OrderFlow.API.Contracts.Requests;
using OrderFlow.Application.Commands.AddOrderItem;
using OrderFlow.Application.Commands.CreateOrder;
using OrderFlow.Application.Queries.GetOrderById;
using Microsoft.AspNetCore.Mvc;

namespace OrderFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateOrderRequest request,
        [FromServices] CreateOrderCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var command = new CreateOrderCommand
        {
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail
        };

        var result = await handler.Handle(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        [FromServices] GetOrderByIdQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(new GetOrderByIdQuery(id), cancellationToken);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("{id:guid}/items")]
    public async Task<IActionResult> AddItem(
        Guid id,
        [FromBody] AddOrderItemRequest request,
        [FromServices] AddOrderItemCommandHandler handler,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = new AddOrderItemCommand
            {
                OrderId = id,
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice
            };

            var result = await handler.Handle(command, cancellationToken);

            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}