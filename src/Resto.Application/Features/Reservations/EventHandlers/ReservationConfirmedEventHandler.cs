using MediatR;
using Resto.Domain.Events;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Domain.Enums;
using Resto.Application.Interfaces.Services;

namespace Resto.Application.Features.Reservations.EventHandlers
{
    public class ReservationCreatedEventHandler(
        ICustomerService customerService,
        INotificationService notificationService
    ) : INotificationHandler<ReservationCreatedEvent>
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly INotificationService _notificationService = notificationService;

        public async Task Handle(ReservationCreatedEvent notification, CancellationToken cancellationToken)
        {
            var customerResult = await _customerService.GetCustomerByIdAsync(new GetCustomerByIdQuery(notification.CustomerId));


            await _notificationService.AddNotificationAsync(new CreateNotificationCommand(
                customerResult.Customer.Id.ToString(),
                $"Your reservation for table {notification.TableNumber} at {notification.ReservationDate} has been successfully created.",
                NotificationType.Confirmation
            ));
            //TODO::Email Service
        }
    }
}
