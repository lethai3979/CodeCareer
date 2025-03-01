using CodeCareer.Application.Login;
using CodeCareer.Application.Recruiters.Commands;
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

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] CreateRecruitersCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Result>> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
