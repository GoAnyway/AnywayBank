using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using CommonData.UtilModels.ErrorModels.Enums;
using Data.Models.EntityModels;
using Data.Requests;
using Database.Entities;
using DataManager.Repositories;
using IdentityCore.Services.UserSecurity.UserSecurityGuards;
using Resources.IdentityCoreResources.Handlers.AuthorizationHandlers;

namespace IdentityCore.Handlers.AuthorizationHandlers
{
    public class AuthorizationRequestHandler : IAuthorizationRequestHandler
    {
        private readonly IIdentityRepository<User> _userRepository;
        private readonly IUserSecurityGuard _userSecurityGuard;
        private readonly IMapper _mapper;

        public AuthorizationRequestHandler(IIdentityRepository<User> userRepository,
            IUserSecurityGuard userSecurityGuard,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userSecurityGuard = userSecurityGuard;
            _mapper = mapper;
        }

        public async Task<OneOfModel<UserModel, DefaultErrorModel>> Handle(AuthorizationRequest request,
            CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserModel>(request);
            var getPersonResult = await _userRepository.GetAsync<UserModel>(_ => _.Username == user.Username);
            if(getPersonResult.IsT1) return BaseErrorModel.Create<DefaultErrorModel>(ErrorCode.BusinessLogic, AuthorizationHandlerErrors.AuthorizationFailed);

            return _userSecurityGuard.ComparePasswords(user, getPersonResult.AsT0)
                ? getPersonResult
                : BaseErrorModel.Create<DefaultErrorModel>(ErrorCode.BusinessLogic, AuthorizationHandlerErrors.AuthorizationFailed);
        }
    }
}