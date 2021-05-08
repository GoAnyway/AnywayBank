using System.Threading.Tasks;
using AutoMapper;
using DataManager.Repositories.PersonRepositories;
using Models.APIModels.Identity;
using Models.InternalModels.EntityModels.Identity;
using Models.UtilModels;

namespace AnywayBankCore.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public IdentityService(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<ResultModel<PersonModel>> RegisterAsync(RegistrationModel model)
        {
            var result = await TryGetPerson(model.Username);
            if (result.Success)
                return ResultModel<PersonModel>.BadResult(2002, "User with similar Username already exists.");

            try
            {
                await _personRepository.BeginTransactionAsync();
                var user = _mapper.Map<UserModel>(model);
                var person = new PersonModel(user);
                var creationResult = _personRepository.Create(person);
                await _personRepository.CommitAsync();
                return creationResult;
            }
            catch
            {
                await _personRepository.RollbackAsync();
                return ResultModel<PersonModel>.BadResult(2002, "Registration failed.");
            }
        }

        public async Task<ResultModel<PersonModel>> AuthorizeAsync(AuthorizationModel model)
        {
            var person = await TryGetPerson(model.Username);

            return person.Success && person.Data.User.Password == model.Password
                ? person
                : ResultModel<PersonModel>.BadResult(2002, "Authorization failed.");
        }

        private async Task<ResultModel<PersonModel>> TryGetPerson(string username) =>
            await _personRepository.GetAsync<PersonModel>(_ => _.User.Username == username);
    }
}