using BuildingBlocks.Models;

namespace Core.Platform.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var tenantClaim = context.User.FindFirst("tenant_id");
            if (tenantClaim != null && !string.IsNullOrWhiteSpace(tenantClaim.Value))
            {
                tenantContext.TenantId = tenantClaim.Value;
            }
        }

        await _next(context);
    }
}
