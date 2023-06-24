using System.Net;
using System.Text.Json;

namespace Cyclix.Exception;

public class GlobalExceptionMiddle
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddle(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context, ILogger<GlobalExceptionMiddle> logger)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                message = exception.Message
            };

            var errorJson = JsonSerializer.Serialize(errorResponse);

            await response.WriteAsync(errorJson);
        }
    }
}