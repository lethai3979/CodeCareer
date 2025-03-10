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

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        [HttpPost("RecruiterRegister")]
        public async Task<IResult> RecruiterRegister([FromBody] CreateRecruiterCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok() : result.ToProblemDetails();
        }


        [HttpPost("Login")]
        public async Task<IResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();

        }

        [HttpGet("GetById/{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IResult> GetById(string id)
        {
            // Chỉ cho phép Admin hoặc chính chủ truy vấn thông tin
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }

        [HttpGet("GetByEmail/{email}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IResult> GetByEmail(string email)
        {
            // Chỉ Admin có quyền tìm kiếm user bằng email
            var result = await _mediator.Send(new GetUserByEmailQuery(email));
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();

        }
    }
}
