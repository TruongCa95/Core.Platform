using System.Data;
using System.Net;
using System.Text.Json;
using FluentValidation;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught by middleware.");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string message = "An unexpected error occurred.";
        switch (exception)
        {
            case DuplicateNameException duplicateEx:
                statusCode = HttpStatusCode.Conflict; // 409
                message = duplicateEx.Message ?? "Duplicate data error.";
                break;

            case ArgumentException argEx:
                statusCode = HttpStatusCode.BadRequest; // 400
                message = argEx.Message ?? "Invalid argument.";
                break;

            case UnauthorizedAccessException unauthorizedEx:
                statusCode = HttpStatusCode.Unauthorized; // 401
                message = unauthorizedEx.Message ?? "Unauthorized access.";
                break;

            case ValidationException validateEx:
                statusCode = HttpStatusCode.BadRequest; // 400
                message = validateEx.Message ?? "Validation failed.";
                break;

            case KeyNotFoundException notfoundEx:
                statusCode = HttpStatusCode.NotFound; // 404
                message = notfoundEx.Message ?? "Record not found.";
                break;

            default:
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new
        {
            error = message,
            statusCode = (int)statusCode
        });

        return context.Response.WriteAsync(result);
    }
}