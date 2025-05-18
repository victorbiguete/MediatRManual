using MediatRManual.Features.Users.Commands.Create;
using MediatRManual.Interface;
using MediatRManual.Mediatr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRManual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediatr _mediator;

        public UserController(IMediatr mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send<CreateUserCommand, bool>(command);

            if (result)
            {
                return Ok("User created successfully");
            }
            else
            {
                return BadRequest("Failed to create user");
            }
        }
    }
}
