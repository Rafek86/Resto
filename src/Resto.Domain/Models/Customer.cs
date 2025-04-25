using Resto.Domain.Common;
using Resto.Domain.Events;
using System;

namespace Resto.Domain.Models
{
    public class Customer : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string IdentityId { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        private Customer() { }

        // Create method
        public static Customer Create(string Name, string Email)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Email = Email,
                IdentityId = Guid.NewGuid().ToString(),
            };

            customer.AddDomainEvent(new UserRegisteredEvent
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            });

            return customer;
        }

        // Update method
        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
           
            AddDomainEvent(new CustomerUpdateEvent
            {
                CustomerId = Id,
                Name = Name,
                Email = Email
            });
        }

        // Delete method
        public void Delete()
        {
            IsDeleted = true;
        }
    }

}