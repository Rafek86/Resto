using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resto.Application.Authentication;
using Resto.Application.DTOs;
using Resto.Application.Features.Orders.Commands.Add;
using Resto.Application.Features.Orders.Commands.Delete;
using Resto.Application.Features.Orders.Commands.Update;
using Resto.Application.Features.Orders.Queries.GetOrder;
using Resto.Application.Features.Orders.Queries.GetOrderByCustomer;
using Resto.Application.Features.Orders.Queries.GetPendingOrders;
using Resto.Domain.Authorization;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //[HasPermission(Permissions.OrdersCreate)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = result.OrderId }, result);
        }

        //[HasPermission(Permissions.OrdersChangeStatus)]
        [HttpPut("{orderId}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderStatus(string orderId, [FromBody] OrderStatusUpdateRequest request)
        {
            var command = new UpdateOrderCommand(orderId, request.OrderStatus);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HasPermission(Permissions.OrdersDelete)]
        [HttpDelete("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            var command = new CancelOrderCommand(orderId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HasPermission(Permissions.OrdersRead)]
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            var query = new GetOrderByIdQuery(orderId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.OrdersRead)]
        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrdersByCustomer(string customerId)
        {
            var query = new GetOrderByCustomerQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.OrdersRead)]
        [HttpGet("pending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingOrders()
        {
            var query = new GetPendingOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }


}