using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Update
{
    class UpdateOrderHandler(IOrderService orderService) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        private readonly IOrderService _orderService = orderService;
        public Task<UpdateOrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            return _orderService.UpdateOrderStatusAsync(request);
        }
    }
}
