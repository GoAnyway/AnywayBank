using System.Threading;
using System.Threading.Tasks;
using Data.Commands.Identity;
using Data.Requests.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnywayBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegistrationCommand command)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _mediator.Send(command, CancellationToken.None);

            return result.Success
                ? new ObjectResult(result.Data)
                : BadRequest(result.Error);
        }

        [HttpPost]
        [Route(nameof(Authorize))]
        public async Task<IActionResult> Authorize(AuthorizationRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _mediator.Send(request, CancellationToken.None);

            return result.Success
                ? new ObjectResult(result.Data)
                : BadRequest(result.Error);
        }
    }
}