using Resto.Domain.Common;
using System;

namespace Resto.Domain.Models
{
    public class Notification : AuditableEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
   
        
        private Notification() { }


        public static Notification Create(string customerId, string message)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                Message = message,
                TimeStamp = DateTime.UtcNow
            };

            return notification;
        }

        // Update method
        public void Update(string message)
        {
            Message = message;
            TimeStamp = DateTime.UtcNow;
        }

    }
}