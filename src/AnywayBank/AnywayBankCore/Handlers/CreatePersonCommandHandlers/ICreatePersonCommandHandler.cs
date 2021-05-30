using AnywayBankCore.BaseHandlers;
using Data.Commands.Account;
using Data.Models.EntityModels.Core;

namespace AnywayBankCore.Handlers.CreatePersonCommandHandlers
{
    public interface ICreatePersonCommandHandler : IAnywayBankRequestHandler<CreatePersonCommand, PersonModel>
    {
    }
}