using Resto.Application.Common.CQRS;

namespace Resto.Application.Features.Notifications.Commands.Create
{
   public record CreateNotificationCommand(string customerId, string message)
        : ICommand<CreateNotificationResult>;

    public record CreateNotificationResult(string Id);
}
