using System;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using Data.Commands;
using Data.Models.EntityModels;
using FluentValidation;
using IdentityCore.Behaviors;
using IdentityCore.Handlers.AuthorizationHandlers;
using IdentityCore.Handlers.RegistrationHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityApi.Utils.Extensions.ServiceCollectionExtensions
{
    internal static class MediatRServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services) =>
            services
                .AddScoped<IRegistrationCommandHandler, RegistrationCommandHandler>()
                .AddScoped<IAuthorizationRequestHandler, AuthorizationRequestHandler>();

        public static IServiceCollection AddValidators(this IServiceCollection services) =>
            services
                .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped<IPipelineBehavior<RegistrationCommand, OneOfModel<UserModel, DefaultErrorModel>>,
                    IdentityValidationPipelineBehavior<RegistrationCommand, UserModel>>();
    }
}