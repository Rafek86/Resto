using Resto.Application.Common.CQRS;
using Resto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Update
{
    public record UpdateOrderCommand(
        string OrderId,
        OrderStatus OrderStatus
        ): ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool isSuccess);
}
