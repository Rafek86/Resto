using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Resto.Application.Authentication
{
    public class PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        : DefaultAuthorizationPolicyProvider(options)
    {

        private readonly AuthorizationOptions _authorizationOptions = options.Value;

        public async override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);
            if (policy is not null)
                return policy;

            var permissionPolicy = new AuthorizationPolicyBuilder()
                .AddRequirements(new PermissionRequirment(policyName))
                .Build();

            _authorizationOptions.AddPolicy(policyName, permissionPolicy);
            return permissionPolicy;
        }
    }
}
