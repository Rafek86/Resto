using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Interfaces.Services;
using Resto.Application.Features.Reservations.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Reservations.Commands.Delete;
using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Domain.Enums;

namespace Resto.Application.Features.Orders.Commands.Delete
{
  public  class CancelOrderHandler(IOrderService orderService) 
        : ICommandHandler<CancelOrderCommand ,CancelOrderResult>
    {
        private readonly IOrderService _orderService = orderService;

        public async Task<CancelOrderResult> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
           return await _orderService.CancelOrderAsync(request);
        }
    } 
}
