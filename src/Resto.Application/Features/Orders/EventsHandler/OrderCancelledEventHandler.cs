using MediatR;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Application.Interfaces.Services;
using Resto.Domain.Enums;
using Resto.Domain.Events;

namespace Resto.Application.Features.Orders.EventsHandler
{
    public class OrderCancelledEventHandler(
        ICustomerService customerService,
        INotificationService notificationService,
        IOrderNotificationService orderNotificationService
    ) : INotificationHandler<OrderStatusUpdatedEvent>
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly INotificationService _notificationService = notificationService;
        private readonly IOrderNotificationService _orderNotificationService = orderNotificationService;

        public async Task Handle(OrderStatusUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerByIdAsync(new GetCustomerByIdQuery(notification.CustomerId));

            await _notificationService.AddNotificationAsync(new CreateNotificationCommand(
                customer.Customer.Id.ToString(),
                $"Your order (ID: {notification.OrderId}) has been cancelled.",
                NotificationType.OrderCancelled
            ));

            await _orderNotificationService.SendOrderCancelledAsync(notification.OrderId, customer.Customer.Email);
        }
    }
}
