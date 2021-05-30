using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class CoreServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) =>
            services
                .AddValidators()
                .AddHandlers()
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    }
}