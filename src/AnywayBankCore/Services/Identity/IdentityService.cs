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
            var result = new ResultModel<PersonModel>(true);

            var usernameAlreadyExists = await UnitOfWork.UserRepository.AnyAsync(_ => _.Username == model.Username);
            if (!usernameAlreadyExists)
            {
                result.Success = false;
                result.Error = new ErrorModel(2002, "User with similar Username already exists.");
                return result;
            }

            try
            {
                await UnitOfWork.BeginTransactionAsync();
                var user = UnitOfWork.UserRepository.Create(Mapper.Map<UserModel>(model));
                var person = UnitOfWork.PersonRepository.Create(new PersonModel());
                person.Data.User = user.Data;

                person = UnitOfWork.PersonRepository.Update(person.Data);
                result.Data = person.Data;
                await UnitOfWork.CommitAsync();
            }
            catch
            {
                result.Success = false;
                result.Error = new ErrorModel(2002, "Registration failed.");
                await UnitOfWork.RollbackAsync();
            }

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