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

        [HttpPost("RecruiterRegister")]
        public async Task<ActionResult> RecruiterRegister([FromBody] CreateRecruiterCommand command)
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
