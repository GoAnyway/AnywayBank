using Database.Entities;
using DataManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped<IIdentityRepository<User>, IdentityRepository<User>>();
    }
}