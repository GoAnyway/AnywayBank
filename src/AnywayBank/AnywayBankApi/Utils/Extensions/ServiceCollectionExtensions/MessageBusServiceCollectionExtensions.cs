using AnywayBankApi.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class MessageBusServiceCollectionExtensions
    {
        public static IServiceCollection
            AddMessageBus(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMassTransit(_ =>
                {
                    _.AddConsumers();
                    _.SetKebabCaseEndpointNameFormatter();
                    _.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(configuration.GetConnectionString("RabbitMQConnection"));
                        cfg.ConfigureEndpoints(context);
                    });
                })
                .AddMassTransitHostedService();

        private static void AddConsumers(this IRegistrationConfigurator configurator) =>
            configurator.AddConsumer<UserRegisteredMessageConsumer>();
    }
}