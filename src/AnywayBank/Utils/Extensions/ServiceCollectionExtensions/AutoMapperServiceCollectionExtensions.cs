using AnywayBank.Utils.MapperProfiles;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class AutoMapperServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddScoped<IConfigurationProvider>(_ =>
                    new MapperConfiguration(cfg =>
                    {
                        cfg.AddExpressionMapping();
                        cfg.AddProfiles(new Profile[]
                        {
                            new IdentityMapperProfile(),
                            new BankMapperProfile()
                        });
                    }))
                .AddScoped<IMapper, Mapper>();
    }
}
