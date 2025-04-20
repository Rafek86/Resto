using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces;
using Resto.Application.Common.Interfaces.Repositories;


namespace Resto.Infrastructure.Repositories
{
    public class NotificationRepository(IApplicationDbContext context) : INotificationRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Notification> _dbSet = context.Notifications;

        public async Task<string> AddNotificationAsync(string message, string recipientId)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid().ToString(),
                Message = message,
                CustomerId = recipientId,
                TimeStamp = DateTime.UtcNow
            };
            await _dbSet.AddAsync(notification);
            await _context.SaveChangesAsync();

            return notification.Id;
        }

        public async Task<bool> DeleteNotificationAsync(string notificationId)
        {
           if(await _dbSet.FindAsync(notificationId) is not { } existingNotification)
            {
                throw new NotFoundException("Notification", notificationId);
            }
            _dbSet.Remove(existingNotification);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<string>> GetAllNotificationsByUserIdAsync(string recipientId)
        {
         return await _dbSet
                .Where(n => n.CustomerId == recipientId)
                .Select(n => n.Message)
                .ToListAsync();
        }
    }
}
