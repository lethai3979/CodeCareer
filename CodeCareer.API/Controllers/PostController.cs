using CodeCareer.API.Extensions;
using CodeCareer.Application.Posts.Commands;
using CodeCareer.Application.Posts.Queries;
using CodeCareer.Domain.Roles;
using CodeCareer.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _userId;
        private readonly IMediator _mediator;

        public PostController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext?.User
                     .FindFirstValue(ClaimTypes.NameIdentifier) ?? "UnknownUser";
        }

        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllPostQuery();
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IResult> GetById(int id)
        {
            var request = new GetPostByIdQuery(id);
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }


        [HttpPost("Create")]
        [Authorize(Roles = Role.Recruiter)]
        public async Task<IResult> Create([FromBody] CreatePostCommand command)
        {
            command.RecruiterId = _userId;
            var results = await _mediator.Send(command);
            if (results.Success)
            {
                return Results.Ok();
            }
            return results.ToProblemDetails();
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = Role.Recruiter)]
        public async Task<IResult> Update(int id, [FromBody] UpdatePostCommand command)
        {
            if (command.Id != id)
            {
                return Results.BadRequest("PostId in the body does not match the PostId in the URL");
            }
            command.RequestUserId = _userId;
            var results = await _mediator.Send(command);
            if (results.Success)
            {
                return Results.Ok();
            }
            return results.ToProblemDetails();
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = Role.Recruiter)]
        public async Task<IResult> Delete(int id)
        {
            var command = new DeletePostCommand();
            command.Id = id;
            command.RequestBy = _userId;
            var results = await _mediator.Send(command);
            if (results.Success)
            {
                return Results.Ok();
            }
            return results.ToProblemDetails();
        }
    }
}
