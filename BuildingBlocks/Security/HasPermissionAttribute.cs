using Microsoft.AspNetCore.Authorization;

namespace BuildingBlocks.Security;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission) : base(policy: permission)
    {
    }
}
