using Resto.Domain.Models.Identity;

namespace Resto.Domain.Models
{
    public class Customer : ApplicationUser
    {
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        private Customer() { }

        public static Customer Create(string Name, string Email)
        {
            var customer = new Customer
            {
                Name = Name,
                Email = Email,
                UserName = Email,
                NormalizedEmail = Email.ToUpper(),  
                NormalizedUserName = Email.ToUpper(),  
            };

            //customer.AddDomainEvent(new UserRegisteredEvent
            //{
            //    CustomerId = customer.Id,
            //    Name = customer.Name,
            //    Email = customer.Email
            //});

            return customer;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
           
            //AddDomainEvent(new CustomerUpdateEvent
            //{
            //    CustomerId = Id,
            //    Name = Name,
            //    Email = Email
            //});
        }

        // Delete method
        public void Delete()
        {
            IsDeleted = true;
        }
    }

}