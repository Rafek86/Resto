using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Resto.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Infrastructure.Identity
{
    public class IdentityService(UserManager<ApplicationUser> userManager ,IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory , IAuthorizationService  authorizationService ) : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService = authorizationService;

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            //var user =await _userManager.FindByIdAsync(userId);
            if (await _userManager.FindByIdAsync(userId) is not { } user) {

                return false;
            }

            var userPrincipal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var authResult = await _authorizationService.AuthorizeAsync(userPrincipal, policyName);

            return authResult.Succeeded;
        }

        public async Task<(bool Result, string UserId)> CreateUserAsync(string userName, string Email ,string password)
        {
            var user = new ApplicationUser { 
             UserName =userName,
             Email = Email
            };

          var result= await _userManager.CreateAsync(user, password);

            return (result.Succeeded ,user.Id);
        }//TODO : Create Custom Result

        public async Task<bool> DeleteUserAsync(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) is not { } user)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }

        public async Task<string?> GetUserNameAsync(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) is not { } user)
            {
                return null;
            }

            return user.UserName;
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }
    }
}
