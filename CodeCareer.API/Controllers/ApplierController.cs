using CodeCareer.API.Extensions;
using CodeCareer.Application.User.Appliers.Commands;
using CodeCareer.Domain.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplierController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _userId;
        public ApplierController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext?.User
                     .FindFirstValue(ClaimTypes.NameIdentifier) ?? "UnknownUser";
        }

        [HttpPost("ApplierRegister")]
        public async Task<IResult> ApplierRegister([FromBody] CreateApplierCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Results.Ok();
            }
            return result.ToProblemDetails();
        }

        [HttpPost("ApplyPost")]
        [Authorize(Roles = Role.Applier)]
        public async Task<IResult> ApplyPost([FromBody] ApplyPostCommand command)
        {
            command.UserId = _userId;
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }
    }
}
