using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.JsonPlaceHolder.Queries.GetCommentsByUserId;
using UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPhotosByUserId;
using UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPostsByUserId;
using UserManagement.Application.Features.JsonPlaceHolder.Queries.GetTodosByUserId;
using UserManagement.Application.Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonPlaceholderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JsonPlaceholderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<JsonPlaceholderController>/5
        [HttpGet("post/{id}")]
        public async Task<ActionResult<List<Post>>> GetPostsByUserId(int id)
        {
            var getPostByUserIdQuery = new GetPostsByUserIdQuery() {  UserId = id };
            var post = await _mediator.Send(getPostByUserIdQuery);
            if(post == null)
            {
                return NotFound("Data not fount");
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpGet("comments/{id}")]
        public async Task<ActionResult<List<Post>>> GetCommentsByUserId(int id)
        {
            var getCommentsByUserIdQuery = new GetCommentsByUserIdQuery() { UserId = id };
            var comments = await _mediator.Send(getCommentsByUserIdQuery);
            if (comments == null)
            {
                return NotFound("Data not fount");
            }
            else
            {
                return Ok(comments);
            }
        }

        [HttpGet("photos/{id}")]
        public async Task<ActionResult<List<Post>>> GetPhotosByUserId(int id)
        {
            var getPhotosByUserIdQuery = new GetPhotosByUserIdQuery() { UserId = id };
            var photos = await _mediator.Send(getPhotosByUserIdQuery);
            if (photos == null)
            {
                return NotFound("Data not fount");
            }
            else
            {
                return Ok(photos);
            }
        }

        [HttpGet("todos/{id}")]
        public async Task<ActionResult<List<Post>>> GetTodosByUserId(int id)
        {
            var getTodosByUserIdQuery = new GetTodosByUserIdQuery() { UserId = id };
            var todos = await _mediator.Send(getTodosByUserIdQuery);
            if (todos == null)
            {
                return NotFound("Data not fount");
            }
            else
            {
                return Ok(todos);
            }
        }
    }
}
