using AnywayBankApi.Utils.MapperProfiles;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class AutoMapperServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddScoped<IConfigurationProvider>(_ =>
                    new MapperConfiguration(cfg =>
                    {
                        cfg.AddExpressionMapping();
                        cfg.AddProfiles(new Profile[]
                        {
                            new CoreMapperProfile(),
                            new BankMapperProfile()
                        });
                    }))
                .AddScoped<IMapper, Mapper>();
    }
}