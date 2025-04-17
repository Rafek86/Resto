using Microsoft.AspNetCore.Identity;
using Resto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Infrastructure.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
