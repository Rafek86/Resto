using Resto.Application.Common.CQRS;
using Resto.Domain.Enums;

namespace Resto.Application.Features.Orders.Commands.Add
{
    public record OrderItemsRequest(
        string MenuItemId,
        int Quantity
    );

    public record PlaceOrderCommand(
        string CustomerId,
        int TableNumber,
        List<OrderItemsRequest> Items
    ) :ICommand<PlaceOrderResult>;

    public record PlaceOrderResult(
        string OrderId,
        decimal TotalPrice,
        string OrderStatus
    );

}
