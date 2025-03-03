using CodeCareer.API.Extensions;
using CodeCareer.Application.Posts.Queries;
using CodeCareer.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCareer.API.Controllers
{
    public class PostController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllPostQuery();
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }
    }
}
