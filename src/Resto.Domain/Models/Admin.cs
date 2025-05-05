using Resto.Domain.Models.Identity;
using System;

namespace Resto.Domain.Models
{
    public class Admin : ApplicationUser
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;


        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        private Admin() { }

        // Create method
        public static Admin Create(string name, string email)
        {
            var admin = new Admin
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Email = email
            };

            return admin;
        }

        // Update method
        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

        // Set as inactive
        public void Deactivate()
        {
            IsActive = false;
        }

        // Set as active
        public void Activate()
        {
            IsActive = true;
        }

        // Delete method
        public void Delete()
        {
            IsActive = false;
        }
    }
}