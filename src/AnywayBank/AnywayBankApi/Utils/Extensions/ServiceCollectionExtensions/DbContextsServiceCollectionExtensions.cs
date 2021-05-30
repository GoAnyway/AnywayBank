using Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class DbContextsServiceCollectionExtensions
    {
        public static IServiceCollection
            AddDbContexts(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AnywayBankDbContext>(builder =>
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DbConnection")));
    }
}