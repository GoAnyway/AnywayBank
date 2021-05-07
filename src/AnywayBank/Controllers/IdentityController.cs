using System.Threading.Tasks;
using AnywayBankCore.Cores;
using Microsoft.AspNetCore.Mvc;
using Models.APIModels.Identity;

namespace AnywayBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ICore _core;

        public IdentityController(ICore core)
        {
            _core = core;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            
            var result = await _core.IdentityService.RegisterAsync(model);
            
            return result.Success
                ? new ObjectResult(result.Data)
                : BadRequest(result.Error);
        }

        [HttpPost]
        [Route(nameof(Authorize))]
        public async Task<IActionResult> Authorize(AuthorizationModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _core.IdentityService.AuthorizeAsync(model);

            return result.Success
                ? new ObjectResult(result.Data)
                : StatusCode(result.Error.Code, result.Error.Message);
        }
    }
}