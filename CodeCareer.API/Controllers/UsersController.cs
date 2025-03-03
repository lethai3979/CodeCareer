using CodeCareer.API.Extensions;
using CodeCareer.Application.User.Login;
using CodeCareer.Application.User.Recruiters.Commands;
using CodeCareer.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/RecruiterRegister")]
        public async Task<IResult> RecruiterRegister([FromBody] CreateRecruiterCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok() : result.ToProblemDetails();
        }


        [HttpPost("Login")]
        public async Task<IResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok() : result.ToProblemDetails();

        }
    }
}
