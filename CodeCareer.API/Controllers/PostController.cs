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

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllPostQuery();
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }
        [HttpPost("create")]
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

    }
}
