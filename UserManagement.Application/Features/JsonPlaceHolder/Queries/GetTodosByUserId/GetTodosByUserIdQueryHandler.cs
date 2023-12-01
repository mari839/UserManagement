using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPostsByUserId;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetTodosByUserId
{
    public class GetTodosByUserIdQueryHandler : IRequestHandler<GetTodosByUserIdQuery, List<Todo>>
    {
        private readonly IJsonPlaceholderClient _placeholderClient;
        public GetTodosByUserIdQueryHandler(IJsonPlaceholderClient jsonPlaceholderClient)
        {
            _placeholderClient = jsonPlaceholderClient;
        }

        public async Task<List<Todo>> Handle(GetTodosByUserIdQuery request, CancellationToken cancellationToken)
        {
            var todos = await _placeholderClient.GetTodosByUserIdAsync(request.UserId);
            return todos;
        }
    }
}
