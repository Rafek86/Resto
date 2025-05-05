using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Orders.Commands.Update
{
    class UpdateOrderHandler(IOrderService orderService) : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        private readonly IOrderService _orderService = orderService;
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderService.UpdateOrderStatusAsync(request);
        }
    }
}
