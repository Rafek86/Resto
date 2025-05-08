using Resto.Domain.Models.Identity;

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

        public static Staff Create(string name, string email, string position)
        {
            var staff = new Staff
            {
                Name = name,
                Email = email,
                Position = position
            };

            return staff;
        }

        public void Update(string name, string email, string position)
        {
            Name = name;
            Email = email;
            Position = position;
        }

        public void Delete()
        {
            IsActive = false;
        }
    }
}