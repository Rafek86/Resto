using Resto.Application.Common.CQRS;
using Resto.Domain.Enums;

namespace Resto.Application.Features.Notifications.Commands.Create
{
    public record CreateNotificationCommand(string UserId, string message, NotificationType type = NotificationType.General) :ICommand<CreateNotificationResult>;

    public record CreateRoleNotificationCommand(UserRole targetRole, string message, NotificationType type = NotificationType.General) : ICommand<CreateNotificationResult>;

    public record CreateNotificationResult(string Id);
}
