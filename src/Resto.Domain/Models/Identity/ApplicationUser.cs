using Microsoft.AspNetCore.Identity;
namespace Resto.Domain.Models.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
