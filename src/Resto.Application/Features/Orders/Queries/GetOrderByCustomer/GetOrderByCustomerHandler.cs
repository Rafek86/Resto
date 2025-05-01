using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetOrderByCustomer
{
   public class GetOrderByCustomerHandler(IOrderService orderService) : IQueryHandler<GetOrderByCustomerQuery, GetOrderByCustomerResult>
    {
        private readonly IOrderService _orderService = orderService;
        public Task<GetOrderByCustomerResult> Handle(GetOrderByCustomerQuery request, CancellationToken cancellationToken)
        {
            return _orderService.GetOrdersForCustomerAsync(request);
        }
    }
}
