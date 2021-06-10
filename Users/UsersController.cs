using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Users.CreateUser;
using MusicApp.Users.DeleteUser;
using MusicApp.Users.GetUser;
using MusicApp.Users.GetUsers;
using MusicApp.Users.UpdateUser;

namespace MusicApp.Users
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserRequest request)
        {
            var command = new CreateUserCommand(request.Password, request.Email, request.UserName);
            var userId = await _mediator.Send(command);
            return CreatedAtAction("Get", new { id = userId }, new { id = userId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateUserRequest request)
        {
            var command = new UpdateUserCommand(id, request.UserName, request.Email, request.Password);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
