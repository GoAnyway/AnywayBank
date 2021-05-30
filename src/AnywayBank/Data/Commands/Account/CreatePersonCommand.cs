using CommonData.Messages;
using Data.BaseRequests;
using Data.Models.EntityModels.Core;

namespace Data.Commands.Account
{
    public class CreatePersonCommand : IAnywayBankRequest<PersonModel>
    {
        public CreatePersonCommand(UserRegisteredMessage message)
        {
            Message = message;
        }

        public UserRegisteredMessage Message { get; }
    }
}