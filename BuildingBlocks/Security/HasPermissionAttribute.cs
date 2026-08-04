using Microsoft.AspNetCore.Authorization;

namespace BuildingBlocks.Security;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission) : base(policy: permission)
    {
    }

    public static string For(string module, string tab, string action)
    {
        return $"{module.ToLowerInvariant()}:{tab.ToLowerInvariant()}:{action.ToLowerInvariant()}";
    }
}
