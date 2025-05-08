namespace Resto.Infrastructure.Repositories
{
    public class NotificationRepository(IApplicationDbContext context) : INotificationRepository
    {
        private readonly IApplicationDbContext _context = context;
        private readonly DbSet<Notification> _dbSet = context.Notifications;

        public async Task<string> AddNotificationAsync(Notification notification)
        {
        
            await _dbSet.AddAsync(notification);
            await _context.SaveChangesAsync();

            return notification.Id;
        }

        public async Task<string> AddRoleNotficationAsync(Notification notification)
        {
            await _dbSet.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification.Id;
        }

        public async Task<string> DeleteNotificationAsync(Notification notification)
        {
            _dbSet.Remove(notification);
            await _context.SaveChangesAsync();
            return notification.Id;
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsByUserIdAsync(string recipientId)
        {
            var items = await _dbSet.Where(r => r.UserId == recipientId).ToListAsync();
            return items;
        }

        public async Task<Notification> GetNotificationByIdAsync(string id)
        {
          return await _dbSet.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
