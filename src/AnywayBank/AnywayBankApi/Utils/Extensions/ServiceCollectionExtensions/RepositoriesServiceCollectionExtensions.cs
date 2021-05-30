using Database.Entities.Core;
using DataManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IAnywayBankRepository<Person>, AnywayBankRepository<Person>>();
    }
}