using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Application.Features.Notifications.Commands.Delete;
using Resto.Application.Features.Notifications.Queries.GetAllById;


namespace Resto.Application.Common.Interfaces.Services
{
   public interface INotificationService
    {
        Task<CreateNotificationResult> AddNotificationAsync(CreateNotificationCommand command);
        Task<DeleteNotificationResult> DeleteNotificationAsync(DeleteNotificationCommand command);
        Task<IEnumerable<GetNotificationResponse>> GetAllNotificationsByUserIdAsync(GetNotificationsQuery query);
        Task<GetNotificationResponse> GetNotificationByIdAsync(string id);
    }
}
