using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetTodosByUserId
{
    public class GetTodosByUserIdQuery : IRequest<List<Todo>>
    {
        public int UserId { get; set; }
    }
}
