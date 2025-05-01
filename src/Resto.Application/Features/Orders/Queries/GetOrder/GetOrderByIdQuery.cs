using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetOrder
{
    public record GetOrderByIdQuery(
        string OrderId
        ) :IQuery<GetOrderByIdResult>;

    public record GetOrderByIdResult(OrderDto Order);
}
