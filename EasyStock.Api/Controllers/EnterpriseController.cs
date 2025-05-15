using EasyStock.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyStock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnterpriseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "SuperUserOnly")]
        public async Task<IActionResult> PostAsync([FromBody] CreateEnterpriseCommand command)
        {
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }
    }
}
