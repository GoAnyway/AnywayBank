using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using CommonData.UtilModels.ErrorModels.Enums;
using Data.Commands;
using Data.Models.EntityModels;
using Database.Entities;
using DataManager.Repositories;
using Resources.IdentityCoreResources.Handlers.RegistrationHandlers;

namespace IdentityCore.Handlers.RegistrationHandlers
{
    public class RegistrationCommandHandler : IRegistrationCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IIdentityRepository<User> _userRepository;

        public RegistrationCommandHandler(IIdentityRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OneOfModel<UserModel, DefaultErrorModel>> Handle(RegistrationCommand request,
            CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserModel>(request);
            var creationResult = _userRepository.Create(user, true);

            await Task.CompletedTask;
            return creationResult.Match(_ => creationResult,
                _ => BaseErrorModel.Create<DefaultErrorModel>(ErrorCode.BusinessLogic, RegistrationHandlerErrors.RegistrationFailed));
        }
    }
}