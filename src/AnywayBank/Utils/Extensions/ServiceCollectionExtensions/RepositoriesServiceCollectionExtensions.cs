using DataManager.Repositories.PersonRepositories;
using DataManager.Repositories.UserRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => 
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IPersonRepository, PersonRepository>();
    }
}