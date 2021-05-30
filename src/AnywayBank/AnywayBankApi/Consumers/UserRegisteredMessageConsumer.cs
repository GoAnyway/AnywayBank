using System.Threading.Tasks;
using CommonData.Messages;
using Data.Commands.Account;
using MassTransit;
using MediatR;

namespace AnywayBankApi.Consumers
{
    public class UserRegisteredMessageConsumer : IConsumer<UserRegisteredMessage>
    {
        private readonly IMediator _mediator;

        public UserRegisteredMessageConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UserRegisteredMessage> context)
        {
            if (context?.Message == null)
            {
                //TODO: Logging.
                return;
            }

            var personCreateCommand = new CreatePersonCommand(context.Message);
            var result = await _mediator.Send(personCreateCommand);
            if (result.IsT1)
            {
                //TODO: Logging.
            }
        }
    }
}