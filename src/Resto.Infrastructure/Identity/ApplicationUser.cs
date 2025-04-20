using Microsoft.AspNetCore.Identity;


namespace Resto.Infrastructure.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public string? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
