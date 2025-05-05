using MediatR;
using Resto.Domain.Events;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Interfaces.Services;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Domain.Enums;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Resto.Application.Features.Orders.EventsHandler
{
    public class OrderPlacedEventHandler(INotificationService notificationService,
        ICustomerService customerService,
        IOrderNotificationService orderNotificationService) : INotificationHandler<OrderPlacedEvent>
    {
        private readonly INotificationService _notificationService = notificationService;
        private readonly ICustomerService _customerService = customerService;
        private readonly IOrderNotificationService _orderNotificationService = orderNotificationService;

        public async Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetCustomerByIdAsync(new GetCustomerByIdQuery(notification.CustomerId));

            await _notificationService.AddNotificationAsync(new CreateNotificationCommand(
                customer.Customer.Id.ToString(),
                $"Your order (ID: {notification.OrderId}) has been successfully placed. Total: {notification.TotalPrice:C}.",
                NotificationType.OrderPlaced
            ));

            await _orderNotificationService.SendOrderConfirmationAsync(notification.OrderId, customer.Customer.Email);
        }

    }
}