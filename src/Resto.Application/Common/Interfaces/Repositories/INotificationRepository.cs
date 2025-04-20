using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task<string> AddNotificationAsync(string message, string recipientId);
        Task<bool> DeleteNotificationAsync(string notificationId);
        Task<IEnumerable<string>> GetAllNotificationsByUserIdAsync(string recipientId);
    }
}
