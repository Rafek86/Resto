using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetOrder
{
  public class GetOrderByIdHandler(IOrderService orderService) : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        private readonly IOrderService _orderService = orderService;
        public Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _orderService.GetOrderDetailsAsync(request);
        }
    }
}
