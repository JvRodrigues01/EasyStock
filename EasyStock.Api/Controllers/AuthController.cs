using EasyStock.Application.Commands.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyStock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AuthCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
