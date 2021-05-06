using Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class DbContextsServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AnywayBankDbContext>(builder => 
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
