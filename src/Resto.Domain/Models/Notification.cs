
namespace Resto.Domain.Models
{
    public class Notification
    {
        public string Id { get; private set; }
        public string UserId { get; private set; }
        public string Message { get; private set; }
        public NotificationType Type { get; private set; }
        public UserRole TargetRole { get; private set; } 


        private Notification() { }

        public static Notification Create(string UserId, string message, NotificationType type = NotificationType.General)
        {
            return new Notification
            {
                Id = Guid.NewGuid().ToString(),
                UserId = UserId,
                Message = message,
                Type = type,
                TargetRole = UserRole.Customer 
            };
        }

        public static Notification CreateForRole(UserRole role, string message, NotificationType type = NotificationType.General)
        {
            return new Notification
            {
                Id = Guid.NewGuid().ToString(),
                Message = message,
                Type = type,
                TargetRole = role
            };
        }
    }
}