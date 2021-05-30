using System;
using IdentityApi.JwtGenerators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class CoreServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) =>
            services
                .AddValidators()
                .AddHandlers()
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<IJwtGenerator, JwtGenerator>();
    }
}