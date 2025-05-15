using System.Security.Claims;
using EasyStock.Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyStock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "AdminOnly,ManagerOnly")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserCommand command)
        {
            command.EnterpriseId = Guid.Parse(User.FindFirstValue(ClaimTypes.GroupSid));
            var result = await _mediator.Send(command);

            return Created(string.Empty, result);
        }
    }
}
