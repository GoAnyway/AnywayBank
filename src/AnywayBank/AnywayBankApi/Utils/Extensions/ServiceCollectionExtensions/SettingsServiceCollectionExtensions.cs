using CommonData.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    public static class SettingsServiceCollectionExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration) =>
            services.AddOptions()
                .Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
    }
}
