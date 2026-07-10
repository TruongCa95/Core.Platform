using System.Net;
using System.Text.Json;

/// <summary>
/// Lightweight API-key authentication gate.
/// Enforcement is opt-in: it only rejects requests when an "ApiKey" value is
/// configured (appsettings / environment). When no key is configured the
/// middleware is a pass-through, so local development is not blocked.
/// Swap this for JWT/OAuth once an identity provider is chosen.
/// </summary>
public class ApiKeyMiddleware
{
    private const string HeaderName = "X-Api-Key";

    private readonly RequestDelegate _next;
    private readonly string? _configuredKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuredKey = configuration["ApiKey"];
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // No key configured -> feature disabled, let everything through.
        if (string.IsNullOrWhiteSpace(_configuredKey))
        {
            await _next(context);
            return;
        }

        // Allow Swagger UI and the OpenAPI document without a key.
        var path = context.Request.Path.Value ?? string.Empty;
        if (path.StartsWith("/swagger", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(HeaderName, out var provided)
            || !string.Equals(provided, _configuredKey, StringComparison.Ordinal))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = "Missing or invalid API key.",
                statusCode = (int)HttpStatusCode.Unauthorized
            }));
            return;
        }

        await _next(context);
    }
}
