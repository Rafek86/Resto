using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Delete
{
  public  class CancelOrderHandler(IOrderService orderService) :ICommandHandler<CancelOrderCommand ,CancelOrderResult>
    {
        private readonly IOrderService _orderService = orderService;

        public Task<CancelOrderResult> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            return _orderService.CancelOrderAsync(request);
        }
    } 
}
