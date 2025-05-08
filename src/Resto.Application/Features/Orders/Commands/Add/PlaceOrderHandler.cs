using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Interfaces.Services;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
namespace Resto.Application.Features.Orders.Commands.Add
{
  public class PlaceOrderHandler(IOrderService orderService,
            ICustomerService customerService
      ) : ICommandHandler<PlaceOrderCommand, PlaceOrderResult>
    {
        private readonly IOrderService _orderService = orderService;
        private readonly ICustomerService _customerService = customerService;

        public async Task<PlaceOrderResult> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
        
            var result = await _orderService.PlaceOrderAsync(request);
            var customer = await _customerService.GetCustomerByIdAsync(new GetCustomerByIdQuery (request.CustomerId));

            return new PlaceOrderResult
            (
                result.OrderId,
                result.TotalPrice,
                result.OrderStatus
            );
        }
    }
}
