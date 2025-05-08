using Resto.Domain.Models.Identity;

namespace Resto.Domain.Models
{
    public class Admin : ApplicationUser
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;


        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        private Admin() { }

        public static Admin Create(string name, string email)
        {
            var admin = new Admin
            {
                Name = name,
                Email = email
            };

            return admin;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void Delete()
        {
            IsActive = false;
        }
    }
}