using AnywayBankCore.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class CoreServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) =>
            services
                .AddScoped<IIdentityService, IdentityService>();
    }
}
