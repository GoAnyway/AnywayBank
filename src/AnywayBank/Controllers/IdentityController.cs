using System.Threading.Tasks;
using AnywayBankCore.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.APIModels.Identity;

namespace AnywayBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            
            var result = await _identityService.RegisterAsync(model);
            
            return result.Success
                ? new ObjectResult(result.Data)
                : BadRequest(result.Error);
        }

        [HttpPost]
        [Route(nameof(Authorize))]
        public async Task<IActionResult> Authorize(AuthorizationModel model)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _identityService.AuthorizeAsync(model);

            return result.Success
                ? new ObjectResult(result.Data)
                : BadRequest(result.Error);
        }
    }
}