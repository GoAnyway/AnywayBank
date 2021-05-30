using Data.Models.EntityModels;
using Data.Requests;
using IdentityCore.BaseHandlers;

namespace IdentityCore.Handlers.AuthorizationHandlers
{
    public interface IAuthorizationRequestHandler : IIdentityRequestHandler<AuthorizationRequest, UserModel>
    {
    }
}