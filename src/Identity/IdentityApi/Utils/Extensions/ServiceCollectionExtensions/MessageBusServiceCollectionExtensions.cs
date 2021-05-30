using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class MessageBusServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMassTransit(_ => _.UsingRabbitMq((_, cfg) => cfg.Host(configuration.GetConnectionString("RabbitMQConnection"))))
                .AddMassTransitHostedService();
    }
}
