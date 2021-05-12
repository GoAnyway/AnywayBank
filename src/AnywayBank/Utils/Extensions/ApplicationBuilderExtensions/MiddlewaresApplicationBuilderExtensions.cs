using AnywayBank.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AnywayBank.Utils.Extensions.ApplicationBuilderExtensions
{
    public static class MiddlewaresApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder appBuilder) =>
            appBuilder.UseMiddleware<ErrorMiddleware>();
    }
}
