using AnywayBankApi.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AnywayBankApi.Utils.Extensions.ApplicationBuilderExtensions
{
    internal static class MiddlewaresApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder appBuilder) =>
            appBuilder.UseMiddleware<ErrorMiddleware>();
    }
}