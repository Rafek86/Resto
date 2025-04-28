using Resto.Application.Common.Pagination;
using Resto.Application.Features.Notifications.Queries.GetAllById;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task<string> AddNotificationAsync(Notification notification);
        Task<string> DeleteNotificationAsync(Notification  notification);
        Task<IEnumerable<Notification>> GetAllNotificationsByUserIdAsync(string recipientId);
        Task<Notification> GetNotificationByIdAsync(string id);
    }
}
