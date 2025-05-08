using Microsoft.AspNetCore.Authorization;

namespace Resto.Application.Authentication
{
    public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
    {
    }
}
