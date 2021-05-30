using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CommonData.UtilModels;
using CommonData.UtilModels.ErrorModels;
using Data.Commands.Account;
using Data.Models.EntityModels.Core;
using Database.Entities.Core;
using DataManager.Repositories;

namespace AnywayBankCore.Handlers.CreatePersonCommandHandlers
{
    public class CreatePersonCommandHandler : ICreatePersonCommandHandler
    {
        private readonly IAnywayBankRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IAnywayBankRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<OneOfModel<PersonModel, DefaultErrorModel>> Handle(CreatePersonCommand request,
            CancellationToken cancellationToken)
        {
            var person = _mapper.Map<PersonModel>(request);
            return await Task.FromResult(_personRepository.Create(person, true));
        }
    }
}