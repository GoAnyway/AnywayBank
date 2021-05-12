using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using Data.Requests.Identity;
using MediatR;

namespace AnywayBankCore.Handlers.Identity.AuthorizationHandlers
{
    public interface IAuthorizationRequestHandler : IRequestHandler<AuthorizationRequest, ResultModel<PersonModel>>
    {
    }
}