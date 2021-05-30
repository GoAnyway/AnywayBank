using IdentityApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace IdentityApi.Utils.Extensions.ApplicationBuilderExtensions
{
    internal static class MiddlewaresApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder appBuilder) =>
            appBuilder.UseMiddleware<ErrorMiddleware>();
    }
}