using BuildingBlocks.Security;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Xunit;

namespace TimeSheetManagement.Tests;

public class PermissionAuthorizationHandlerTests
{
    [Fact]
    public async Task HandleAsync_Succeeds_WhenPermissionClaimIsJsonArray()
    {
        var handler = new PermissionAuthorizationHandler();
        var requirement = new PermissionRequirement("timesheet:view");
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim("permissions", "[\"timesheet:view\",\"timesheet:create\"]")
        }, "TestAuth"));

        var context = new AuthorizationHandlerContext(new[] { requirement }, principal, null);

        await handler.HandleAsync(context);

        Assert.True(context.HasSucceeded);
    }
}
