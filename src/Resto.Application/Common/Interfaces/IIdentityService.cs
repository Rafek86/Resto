using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(bool Result, string UserId)> CreateUserAsync(string userName, string Email, string password);

        Task<bool> DeleteUserAsync(string userId);
    }
}
