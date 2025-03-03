using CodeCareer.API.Extensions;
using CodeCareer.Application.User.Login;
using CodeCareer.Application.User.Query;
using CodeCareer.Application.User.Query.email;
using CodeCareer.Application.User.Query.Id;
using CodeCareer.Application.User.Recruiters.Commands;
using CodeCareer.Domain.Roles;
using CodeCareer.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string? _userId;
        private readonly string? _email;

        public UsersController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _email = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
           
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
        [Authorize(Roles = Role.Admin)]
        [HttpGet("getbyid/{id}")]
        public async Task<IResult> GetById(string id)
        {
            // Chỉ cho phép Admin hoặc chính chủ truy vấn thông tin         
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
            

        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet("getbyemail/{email}")]
        public async Task<IResult> GetByEmail(string email)
        {
            // Chỉ Admin có quyền tìm kiếm user bằng email
            var result = await _mediator.Send(new GetUserByEmailQuery(email));
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();

        }
    }
}
