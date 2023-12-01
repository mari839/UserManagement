using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Application.Features.Users.Commands.DeleteUser;
using UserManagement.Application.Features.Users.Commands.UpdateUser;
using UserManagement.Application.Features.Users.Queries.GetUser;
using UserManagement.Application.Features.Users.Queries.GetUserList;
using UserManagement.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UserController>

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int id)
        {
            var getUserQuery = new GetUserQuery() { id = id };
            
            var user = await _mediator.Send(getUserQuery);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<UserController>/5
        [HttpGet]
        public async Task<ActionResult<List<GetUserListDto>>> GetUserList()
        {
            var userList = await _mediator.Send(new GetUserListQuery());
            return userList;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserCommand createUserCommand)
        {
            var res = await _mediator.Send(createUserCommand);
            return Ok(res);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult<UpdateUserDto>> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var res = await _mediator.Send(updateUserCommand);
            if(res != null)
            {

            return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void DeleteUser(int id)
        {
            DeleteUserCommand deleteUserCommand = new DeleteUserCommand() { Id = id };
            await _mediator.Send(deleteUserCommand);
        }
    }
}
