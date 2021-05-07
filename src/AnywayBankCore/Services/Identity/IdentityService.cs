using System.Threading.Tasks;
using AnywayBankCore.BaseServices;
using AutoMapper;
using DataManager.UnitsOfWork.AnywayBankUnitsOfWork;
using Models.APIModels.Identity;
using Models.InternalModels.EntityModels.Identity;
using Models.UtilModels;

namespace AnywayBankCore.Services.Identity
{
    public class IdentityService : BaseService, IIdentityService
    {
        public IdentityService(IAnywayBankUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }

        public async Task<ResultModel<PersonModel>> RegisterAsync(RegistrationModel model)
        {
            var result = new ResultModel<PersonModel>(false);

            var userAlreadyExists = await UnitOfWork.UserRepository.AnyAsync(_ => _.Username == model.Username);
            if (userAlreadyExists)
            {
                result.Error = new ErrorModel(2002, "User with similar Username already exists.");
                return result;
            }

            var user = Mapper.Map<UserModel>(model);
            var userCreationResult = UnitOfWork.UserRepository.Create(user);
            if (!userCreationResult.Success)
            {
                result.Error = userCreationResult.Error;
                return result;
            }

            var person = new PersonModel { User = user };
            var personCreationResult = UnitOfWork.PersonRepository.Create(person);
            if (!personCreationResult.Success)
            {
                result.Error = personCreationResult.Error;
                return result;
            }

            userCreationResult.Data.Person = personCreationResult.Data;
            var userUpdateResult = UnitOfWork.UserRepository.Update(userCreationResult.Data);
            if(!userUpdateResult.Success)
            {
                result.Error = userUpdateResult.Error;
                return result;
            }
            await UnitOfWork.SaveChangesAsync();

            personCreationResult.Data.User = userUpdateResult.Data;
            result.Success = true;
            result.Data = personCreationResult.Data;

            return result;
        }

        public async Task<ResultModel<PersonModel>> AuthorizeAsync(AuthorizationModel model)
        {
            var result = new ResultModel<PersonModel>(true);

            var userSearchResult = await UnitOfWork.UserRepository.GetAsync(_ => _.Username == model.Username && 
                                                                                 _.Password == model.Password);
            if (userSearchResult.Success)
            {
                result.Data = Mapper.Map<PersonModel>(userSearchResult.Data.Person);
            }
            else
            {
                result.Success = false;
                result.Error = userSearchResult.Error;
            }

            return result;
        }
    }
}