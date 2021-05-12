using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Commands.Identity;
using Data.Models.InternalModels.EntityModels.Identity;
using Data.Models.UtilModels;
using DataManager.Repositories.PersonRepositories;

namespace AnywayBankCore.Handlers.Identity.RegistrationHandlers
{
    public class RegistrationCommandHandler : BaseIdentityHandler, IRegistrationCommandHandler
    {
        private readonly IMapper _mapper;

        public RegistrationCommandHandler(IPersonRepository personRepository, IMapper mapper)
            : base(personRepository)
        {
            _mapper = mapper;
        }

        public async Task<ResultModel<PersonModel>> Handle(RegistrationCommand request,
            CancellationToken cancellationToken)
        {
            var result = await TryGetPerson(request.Username);
            if (result.Success)
                return ResultModel<PersonModel>.BadResult(2002, "User with similar Username already exists.");

            try
            {
                await PersonRepository.BeginTransactionAsync();
                var user = _mapper.Map<UserModel>(request);
                var person = new PersonModel(user);
                var creationResult = PersonRepository.Create(person);
                await PersonRepository.CommitAsync();
                return creationResult;
            }
            catch
            {
                await PersonRepository.RollbackAsync();
                return ResultModel<PersonModel>.BadResult(2002, "Registration failed.");
            }
        }
    }
}