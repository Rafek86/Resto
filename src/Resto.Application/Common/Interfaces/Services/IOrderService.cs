using Resto.Application.Features.Orders.Commands.Add;
using Resto.Application.Features.Orders.Commands.Delete;
using Resto.Application.Features.Orders.Commands.Update;
using Resto.Application.Features.Orders.Queries.GetOrder;
using Resto.Application.Features.Orders.Queries.GetOrderByCustomer;
using Resto.Domain.Models;

namespace Resto.Application.Common.Interfaces.Services
{
  public interface IOrderService
    {
        Task<PlaceOrderResult> PlaceOrderAsync(PlaceOrderCommand command);
        Task<UpdateOrderResult> UpdateOrderStatusAsync(UpdateOrderCommand command);
        Task<CancelOrderResult> CancelOrderAsync(CancelOrderCommand command);

        Task<GetOrderByIdResult> GetOrderDetailsAsync(GetOrderByIdQuery query);
        Task<GetOrderByCustomerResult> GetOrdersForCustomerAsync(GetOrderByCustomerQuery query);
    }
}
