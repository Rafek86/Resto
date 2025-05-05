using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Commands.Create
{
    public class CreateRoleNotificationCommandHandler(INotificationService notificationService) : ICommandHandler<CreateRoleNotificationCommand, CreateNotificationResult>
    {
        private readonly INotificationService _notificationService = notificationService;

        public async Task<CreateNotificationResult> Handle(CreateRoleNotificationCommand request, CancellationToken cancellationToken)
        {
          return await _notificationService.AddNotificationForRoleAsync(request);
        }
    }
}
