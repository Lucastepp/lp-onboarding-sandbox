using System.Net;
using System.Text.Json;
using LP.Api.Customer.Onboarding.Exceptions;

namespace LP.Api.Customer.Onboarding.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private static Task HandleException(HttpContext context, Exception ex)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var response = new
        {
            error = "internal_error",
            message = "Unexpected error"
        };

        if (ex is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            response = new
            {
                error = "not_found",
                message = ex.Message
            };
        }
        else if (ex is DuplicateEmailException)
        {
            statusCode = HttpStatusCode.BadRequest;
            response = new
            {
                error = "duplicate_email",
                message = ex.Message
            };
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}