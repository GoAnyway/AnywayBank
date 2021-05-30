using System;
using AnywayBankCore.Handlers.Identity.AuthorizationHandlers;
using AnywayBankCore.Handlers.Identity.RegistrationHandlers;
using AnywayBankCore.Validation;
using Data.Commands.Identity;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using Data.Models.UtilModels.ErrorModels;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AnywayBank.Utils.Extensions.ServiceCollectionExtensions
{
    public static class MediatRServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services) =>
            services
                .AddScoped<IRegistrationCommandHandler, RegistrationCommandHandler>()
                .AddScoped<IAuthorizationRequestHandler, AuthorizationRequestHandler>();

        public static IServiceCollection AddValidators(this IServiceCollection services) =>
            services
                .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<IPipelineBehavior<RegistrationCommand, OneOfModel<PersonModel, DefaultErrorModel>>,
                    ValidationPipelineBehaviour<RegistrationCommand, OneOfModel<PersonModel, DefaultErrorModel>,
                        PersonModel, DefaultErrorModel>>();
    }
}
