using System.Threading.Tasks;
using AutoMapper;
using CommonData.Messages;
using Data.Commands;
using Data.Models.EntityModels;
using Data.Requests;
using Data.Responses;
using IdentityApi.JwtGenerators;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IJwtGenerator _jwtGenerator;

        public IdentityController(IMediator mediator,
            IPublishEndpoint publishEndpoint,
            IJwtGenerator jwtGenerator,
            IMapper mapper)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegistrationCommand command)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _mediator.Send(command);
            return await result.Match<Task<IActionResult>>(async data =>
                {
                    await _publishEndpoint.Publish(_mapper.Map<UserRegisteredMessage>(data));
                    AddJwtTokenToHeader(data);
                    return Ok(_mapper.Map<UserResponse>(data));
                },
                error => Task.FromResult<IActionResult>(BadRequest(error)));
        }

        [HttpPost]
        [Route(nameof(Authorize))]
        public async Task<IActionResult> Authorize(AuthorizationRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _mediator.Send(request);
            return result.Match<IActionResult>(data =>
            {
                AddJwtTokenToHeader(data);
                return Ok(_mapper.Map<UserResponse>(data));
            }, BadRequest);
        }

        private void AddJwtTokenToHeader(UserModel user)
        {
            var jwtToken = _jwtGenerator.GenerateJwtToken(user);
            Response.Headers.Add(JwtBearerDefaults.AuthenticationScheme, jwtToken);
        }
    }
}