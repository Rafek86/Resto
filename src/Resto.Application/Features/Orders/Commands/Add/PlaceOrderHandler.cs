using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Add
{
  public class PlaceOrderHandler(IOrderService orderService) : ICommandHandler<PlaceOrderCommand, PlaceOrderResult>
    {
        private readonly IOrderService _orderService = orderService;

        public Task<PlaceOrderResult> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
          return _orderService.PlaceOrderAsync(request);
        }
    }
}
