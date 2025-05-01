using Resto.Application.Common.CQRS;
using Resto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Add
{
    public record PlaceOrderCommand(
        string CustomerId,
        int TableNumber,
        List<(string MenuItemId, int Quantity)> Items
    ) :ICommand<PlaceOrderResult>;

    public record PlaceOrderResult(
        string OrderId,
        decimal TotalPrice,
        OrderStatus OrderStatus
    );

}
