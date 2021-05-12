using System.Threading;
using System.Threading.Tasks;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using Data.Requests.Identity;
using DataManager.Repositories.PersonRepositories;

namespace AnywayBankCore.Handlers.Identity.AuthorizationHandlers
{
    public class AuthorizationRequestHandler : BaseIdentityHandler, IAuthorizationRequestHandler
    {
        public AuthorizationRequestHandler(IPersonRepository personRepository)
            : base(personRepository)
        {
        }

        public async Task<ResultModel<PersonModel>> Handle(AuthorizationRequest request,
            CancellationToken cancellationToken)
        {
            var person = await TryGetPerson(request.Username);

            return person.Success && person.Data.User.Password == request.Password
                ? person
                : ResultModel<PersonModel>.BadResult(2002, "Authorization failed.");
        }
    }
}