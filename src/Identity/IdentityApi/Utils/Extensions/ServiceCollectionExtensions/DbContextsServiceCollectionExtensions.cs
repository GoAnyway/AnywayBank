using Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class DbContextsServiceCollectionExtensions
    {
        public static IServiceCollection
            AddDbContexts(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<IdentityDbContext>(builder =>
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DbConnection")));
    }
}