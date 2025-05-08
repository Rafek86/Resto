using Microsoft.AspNetCore.Authorization;
using Resto.Domain.Authorization;
namespace Resto.Application.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirment>
    {
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirment requirement)
        {

            if (context.User.Identity is not { IsAuthenticated: true }
            || !context.User.Claims.Any(x => x.Value == requirement.Permission && x.Type == Permissions.Type))
                return;

            context.Succeed(requirement);
            return;
        }
    }
}
