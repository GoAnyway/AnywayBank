using System;
using IdentityApi.JwtGenerators;
using IdentityCore.Services.UserSecurity.PasswordHashers;
using IdentityCore.Services.UserSecurity.PasswordSecretGenerators;
using IdentityCore.Services.UserSecurity.UserSecurityGuards;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class CoreServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) =>
            services
                .AddScoped<IJwtGenerator, JwtGenerator>()
                .AddScoped<IPasswordSecretGenerator, PasswordSecretGenerator>()
                .AddScoped<IPasswordHasher, Sha256PasswordHasher>()
                .AddScoped<IUserSecurityGuard, UserSecurityGuard>()
                .AddValidators()
                .AddHandlers()
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    }
}