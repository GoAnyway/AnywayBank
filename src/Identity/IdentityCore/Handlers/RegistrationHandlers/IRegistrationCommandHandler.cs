using Data.Commands;
using Data.Models.EntityModels;
using IdentityCore.BaseHandlers;

namespace IdentityCore.Handlers.RegistrationHandlers
{
    public interface IRegistrationCommandHandler : IIdentityRequestHandler<RegistrationCommand, UserModel>
    {
    }
}