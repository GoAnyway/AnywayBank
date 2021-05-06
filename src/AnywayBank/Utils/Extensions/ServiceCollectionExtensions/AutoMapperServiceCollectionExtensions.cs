﻿using AnywayBank.Utils.MapperProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class AutoMapperServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddScoped<IConfigurationProvider>(_ =>
                    new MapperConfiguration(cfg => cfg.AddProfiles(new Profile[]
                    {
                        new IdentityMapperProfile()
                    })))
                .AddScoped<IMapper, Mapper>();
    }
}