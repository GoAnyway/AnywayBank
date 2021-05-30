using System.Threading.Tasks;
using CommonUtils.Extensions;
using Data.Commands.Account;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnywayBankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route(nameof(FillInPersonDetails))]
        public async Task<IActionResult> FillInPersonDetails(FillInPersonDetailsCommand command)
        {
            command.PersonId = HttpContext.GetIdFromJwtToken();
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(Ok, BadRequest);
        }
    }
}
