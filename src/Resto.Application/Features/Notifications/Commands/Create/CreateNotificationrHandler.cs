using Mapster;
using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.DTOs;
using Resto.Application.Features.Notifications.Commands.Create;

namespace Resto.Application.Features.Notifications.Commands.Create
{
    public class CreateNotificationrHandler(INotificationService notificationService) : ICommandHandler<CreateNotificationCommand, CreateNotificationResult>
    {
        private readonly INotificationService _notificationService = notificationService;

        public async Task<CreateNotificationResult> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
                return await _notificationService.AddNotificationAsync(request);
        }
    }
}
