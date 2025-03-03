using CodeCareer.Application.User.Appliers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplierController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplierController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Regiter([FromBody] CreateApplierCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Error);
        }
    }
}
