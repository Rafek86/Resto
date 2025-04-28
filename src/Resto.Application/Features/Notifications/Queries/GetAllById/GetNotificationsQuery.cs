using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Queries.GetAllById
{
    public record GetNotificationsQuery(string CustomerId) : IQuery<IEnumerable<GetNotificationResponse>>;

    public record GetNotificationResponse(string Name ,DateTime TimeStamp);
}
