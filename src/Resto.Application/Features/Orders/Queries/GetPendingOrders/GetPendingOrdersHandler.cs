using MediatR;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetPendingOrders
{
    public class GetPendingOrdersHandler(IOrderService orderService) : IRequestHandler<GetPendingOrdersQuery, GetPendingOrdersResult>
    {
        private readonly IOrderService _orderService= orderService;

        public async Task<GetPendingOrdersResult> Handle(GetPendingOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetPendingOrdersAsync(request);
        }
    }
}
