using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace BuildingBlocks.Security;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated != true)
        {
            return Task.CompletedTask;
        }

        var permissions = context.User.FindAll("permissions")
            .SelectMany(ExtractPermissions)
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Distinct(StringComparer.OrdinalIgnoreCase);

        if (permissions.Contains(requirement.Permission, StringComparer.OrdinalIgnoreCase))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }

    private static IEnumerable<string> ExtractPermissions(Claim claim)
    {
        if (string.IsNullOrWhiteSpace(claim.Value))
        {
            return Enumerable.Empty<string>();
        }

        if (claim.Value.StartsWith("[", StringComparison.Ordinal) && claim.Value.EndsWith("]", StringComparison.Ordinal))
        {
            try
            {
                var parsed = JsonSerializer.Deserialize<List<string>>(claim.Value);
                if (parsed != null)
                {
                    return parsed.Where(item => !string.IsNullOrWhiteSpace(item));
                }
            }
            catch (JsonException)
            {
            }
        }

        return new[] { claim.Value };
    }
}
