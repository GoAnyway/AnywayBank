using System;
using AnywayBankCore.Handlers.Identity.AuthorizationHandlers;
using AnywayBankCore.Handlers.Identity.RegistrationHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class CoreServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) =>
            services
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<IRegistrationCommandHandler, RegistrationCommandHandler>()
                .AddScoped<IAuthorizationRequestHandler, AuthorizationRequestHandler>();
    }
}
