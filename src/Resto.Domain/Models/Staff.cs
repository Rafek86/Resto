using Resto.Domain.Models.Identity;
using System;
using System.Collections.Generic;

namespace Resto.Domain.Models
{
    public class Staff : ApplicationUser
    {
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Order> HandledOrders { get; set; } = new List<Order>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        private Staff() { }

        // Create method
        public static Staff Create(string name, string email, string position)
        {
            var staff = new Staff
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Email = email,
                Position = position
            };

            return staff;
        }

        // Update method
        public void Update(string name, string email, string position)
        {
            Name = name;
            Email = email;
            Position = position;
        }

        // Delete method
        public void Delete()
        {
            IsActive = false;
        }
    }
}