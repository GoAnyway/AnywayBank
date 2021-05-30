using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using IdentityApi.Utils.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
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
                            new IdentityMapperProfile()
                        });
                    }))
                .AddScoped<IMapper, Mapper>();
    }
}