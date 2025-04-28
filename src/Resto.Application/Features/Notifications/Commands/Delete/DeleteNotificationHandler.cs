using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Notifications.Commands.Delete
{
    public class DeleteNotificationHandler(INotificationService notificationService) : ICommandHandler<DeleteNotificationCommand, DeleteNotificationResult>
    {
        private readonly INotificationService _notificationService = notificationService;

        public Task<DeleteNotificationResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
           return _notificationService.DeleteNotificationAsync(request);
        }
    }
}
