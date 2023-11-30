using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Application.Features.Users.Queries.GetUser;
using UserManagement.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Api.Controllers
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
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int id)
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post(CreateUserCommand createUserCommand)
        {
            var res = await _mediator.Send(createUserCommand);
            return Ok(res);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
