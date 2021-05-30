using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using Data.Commands.Account;
using Data.Models.EntityModels.Core;
using Database.Entities.Core;
using DataManager.Repositories;

namespace AnywayBankCore.Handlers.FillInPersonDetailsHandlers
{
    public class FillInPersonDetailsCommandHandler : IFillInPersonDetailsCommandHandler
    {
        private readonly IAnywayBankRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        public FillInPersonDetailsCommandHandler(IAnywayBankRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<OneOfModel<PersonModel, DefaultErrorModel>> Handle(FillInPersonDetailsCommand request,
            CancellationToken cancellationToken)
        {
            var getPersonResult = await _personRepository.GetAsync<PersonModel>(_ => _.Id == request.PersonId);
            return getPersonResult.Match(person =>
            {
                _mapper.Map(request, person);
                return _personRepository.Update(person, true);
            }, _ => BaseErrorModel.Create<DefaultErrorModel>(2002, "Person with this UserID not found!"));
        }
    }
}