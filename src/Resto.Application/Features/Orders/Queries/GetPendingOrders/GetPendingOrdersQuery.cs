using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetPendingOrders
{
   public record GetPendingOrdersQuery(): IQuery<GetPendingOrdersResult>;

   public record GetPendingOrdersResult(List<OrderDto> pendingOrders);
}
