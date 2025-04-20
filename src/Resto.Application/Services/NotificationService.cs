using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Services
{
    public class NotificationService(INotificationRepository notificationRepository) : INotificationService
    {
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task<string> AddNotificationAsync(string message, string recipientId)
        {
            return await _notificationRepository.AddNotificationAsync(message, recipientId);
        }

        public async Task<IEnumerable<string>> GetAllNotificationsByUserIdAsync(string recipientId)
        {
            return await _notificationRepository.GetAllNotificationsByUserIdAsync(recipientId);
        }

        public async Task<bool> DeleteNotificationAsync(string notificationId)
        {
            return await _notificationRepository.DeleteNotificationAsync(notificationId); 
        }

    }
}
