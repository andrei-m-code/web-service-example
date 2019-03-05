using Microsoft.AspNetCore.Builder;

namespace ExampleService.Middleware
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExampleExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            return app;
        }
    }
}
