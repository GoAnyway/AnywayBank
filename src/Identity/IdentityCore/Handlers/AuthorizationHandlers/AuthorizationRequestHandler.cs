using System.Threading;
using System.Threading.Tasks;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using Data.Models.EntityModels;
using Data.Requests;
using Database.Entities;
using DataManager.Repositories;

namespace IdentityCore.Handlers.AuthorizationHandlers
{
    public class AuthorizationRequestHandler : IAuthorizationRequestHandler
    {
        private readonly IIdentityRepository<User> _userRepository;

        public AuthorizationRequestHandler(IIdentityRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OneOfModel<UserModel, DefaultErrorModel>> Handle(AuthorizationRequest request,
            CancellationToken cancellationToken)
        {
            var getPersonResult = await _userRepository.GetAsync<UserModel>(_ => _.Username == request.Username && 
                                                                                 _.Password == request.Password);

            return getPersonResult.Match(_ => getPersonResult, 
                _ => BaseErrorModel.Create<DefaultErrorModel>(2002, "Authorization failed."));
        }
    }
}