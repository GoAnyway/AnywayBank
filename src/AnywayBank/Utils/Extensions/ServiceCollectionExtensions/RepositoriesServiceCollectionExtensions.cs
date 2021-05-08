using DataManager.Repositories.PersonRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => 
            services
                .AddScoped<IPersonRepository, PersonRepository>();
    }
}