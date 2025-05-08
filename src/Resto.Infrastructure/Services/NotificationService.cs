using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Application.Features.Notifications.Commands.Delete;
using Resto.Application.Features.Notifications.Queries.GetAllById;

namespace Resto.Application.Services
{
    public class NotificationService(INotificationRepository notificationRepository) : INotificationService
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task<CreateNotificationResult> AddNotificationAsync(CreateNotificationCommand command)
        {
            var notification = Notification.Create(command.UserId, command.message,command.type);
            await _notificationRepository.AddNotificationAsync(notification);

            return new CreateNotificationResult(notification.Id);
        }

        public async Task<CreateNotificationResult> AddNotificationForRoleAsync(CreateRoleNotificationCommand command)
        {
           var notification = Notification.CreateForRole(command.targetRole, command.message,command.type);
            await _notificationRepository.AddRoleNotficationAsync(notification);
            return new CreateNotificationResult(notification.Id);
        }


        public async Task<DeleteNotificationResult> DeleteNotificationAsync(DeleteNotificationCommand command)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(command.Id);
            if (notification == null)
            {
                throw new NotFoundException("Notification", command.Id);
            }

            await _notificationRepository.DeleteNotificationAsync(notification);
            return new DeleteNotificationResult(true);
        }

        public async Task<IEnumerable<GetNotificationResponse>> GetAllNotificationsByUserIdAsync(GetNotificationsQuery query)
        {
            var notifications = await _notificationRepository.GetAllNotificationsByUserIdAsync(query.CustomerId);

            if (!notifications.Any())
            {
                return Enumerable.Empty<GetNotificationResponse>();
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
