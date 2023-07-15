using Cyclix.Exception;

namespace Cyclix.Extensions;

public static class GlobalExceptionExtension
{
    public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}