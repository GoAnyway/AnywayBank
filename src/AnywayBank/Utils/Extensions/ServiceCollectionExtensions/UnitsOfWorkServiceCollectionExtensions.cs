using DataManager.UnitsOfWork.AnywayBankUnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class UnitsOfWorkServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitsOfWork(this IServiceCollection services) => 
            services
                .AddScoped<IAnywayBankUnitOfWork, AnywayBankUnitOfWork>();
    }
}
