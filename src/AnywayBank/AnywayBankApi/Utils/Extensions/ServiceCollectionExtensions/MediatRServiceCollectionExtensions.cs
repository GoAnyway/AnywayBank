using System;
using AnywayBankCore.Handlers.CreatePersonCommandHandlers;
using AnywayBankCore.Handlers.FillInPersonDetailsHandlers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBankApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class MediatRServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services) =>
            services
                .AddScoped<ICreatePersonCommandHandler, CreatePersonCommandHandler>()
                .AddScoped<IFillInPersonDetailsCommandHandler, FillInPersonDetailsCommandHandler>();

        public static IServiceCollection AddValidators(this IServiceCollection services) =>
            services
                .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    }
}