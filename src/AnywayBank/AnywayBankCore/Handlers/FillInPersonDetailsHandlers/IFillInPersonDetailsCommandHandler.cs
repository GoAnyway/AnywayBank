using AnywayBankCore.BaseHandlers;
using Data.Commands.Account;
using Data.Models.EntityModels.Core;

namespace AnywayBankCore.Handlers.FillInPersonDetailsHandlers
{
    public interface IFillInPersonDetailsCommandHandler : IAnywayBankRequestHandler<FillInPersonDetailsCommand, PersonModel>
    {
    }
}