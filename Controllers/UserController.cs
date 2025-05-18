using MediatRManual.Domain;
using MediatRManual.Features.Users.Commands.Create;
using MediatRManual.Features.Users.Commands.Delete;
using MediatRManual.Features.Users.Commands.Update;
using MediatRManual.Features.Users.Queries.GetAllUser;
using MediatRManual.Features.Users.Queries.GetUserById;
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

        [HttpPost("/Create")]
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

        [HttpGet("/GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send<GetAllUserQuery, List<User>>(new GetAllUserQuery());

            if(result == null || result.Count == 0)
                return NotFound("No users found");
            
            return Ok(result);
        }

        [HttpGet("/GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _mediator.Send<GetUserByIdQuery,User>(new GetUserByIdQuery(id));

            if (result == null)
                return NotFound("Usuario não Encontrado");

            return Ok(result);
        }

        [HttpPut("/UpdateUser")]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await _mediator.Send<UpdateUserCommand, bool>(command);

            if (!result)
                return BadRequest("Ocorreu um Erro na Atualização do Usuario");

            return Ok("Atualização bem sucedida");
        }

        [HttpDelete("/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send<DeleteUserByIdCommand,bool>(new DeleteUserByIdCommand(id));

            if (!result)
                return BadRequest("Ocorreu um Erro na hora de Remover o Usuario");

            return Ok("Remoção bem sucedida");
        }
    }
}
