using Mapster;
using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Application.Features.Notifications.Commands.Delete;
using Resto.Application.Features.Notifications.Queries.GetAllById;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Services
{
    public class NotificationService(INotificationRepository notificationRepository) : INotificationService
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task<CreateNotificationResult> AddNotificationAsync(CreateNotificationCommand command)
        {
            var notification = Notification.Create(command.customerId, command.message);
            await _notificationRepository.AddNotificationAsync(notification);

            return new CreateNotificationResult(notification.Id);
        }

        public async Task<DeleteNotificationResult> DeleteNotificationAsync(DeleteNotificationCommand command)
        {
           if(await _notificationRepository.GetNotificationByIdAsync(command.Id) is not { } notification)
            {
                throw new NotFoundException("Notification" ,$"{command.Id}");
            }
            await _notificationRepository.DeleteNotificationAsync(notification);
            return new DeleteNotificationResult(true);
        }

        public async Task<IEnumerable<GetNotificationResponse>> GetAllNotificationsByUserIdAsync(GetNotificationsQuery query)
        {
           if(await _notificationRepository.GetAllNotificationsByUserIdAsync(query.CustomerId) is not { } notifications)
            {
                throw new NotFoundException("Notification", query.CustomerId);
            }
            return notifications.Adapt<IEnumerable<GetNotificationResponse>>();
        }

        public async Task<GetNotificationResponse> GetNotificationByIdAsync(string id)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(id);

            if (notification is null)
            {
                throw new NotFoundException("Notification", id);
            }

            return notification.Adapt<GetNotificationResponse>();
        }
    }
}
