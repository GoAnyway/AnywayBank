using Data.Commands.Identity;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using MediatR;

namespace AnywayBankCore.Handlers.Identity.RegistrationHandlers
{
    public interface IRegistrationCommandHandler : IRequestHandler<RegistrationCommand, ResultModel<PersonModel>>
    {
    }
}