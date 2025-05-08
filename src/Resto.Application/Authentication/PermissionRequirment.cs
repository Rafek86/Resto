using Microsoft.AspNetCore.Authorization;

namespace Resto.Application.Authentication
{
    public class PermissionRequirment(string permission) : IAuthorizationRequirement
    {
        public string Permission { get; } = permission;
    }

}
