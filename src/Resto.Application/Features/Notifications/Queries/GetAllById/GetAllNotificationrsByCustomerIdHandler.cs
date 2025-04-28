using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Common.Pagination;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Queries.GetAllById
{
    public class GetAllNotificationsByCustomerIdHandler(INotificationService notificationService) :IQueryHandler<GetNotificationsQuery, IEnumerable<GetNotificationResponse>>
    {
        private readonly INotificationService _notificationService =notificationService;

        public async Task<IEnumerable<GetNotificationResponse>> Handle(GetNotificationsQuery query, CancellationToken cancellationToken)
        {
            return await _notificationService.GetAllNotificationsByUserIdAsync(query);
        }
    }
}
