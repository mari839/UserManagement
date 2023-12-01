using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPostsByUserId;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetCommentsByUserId
{
    public class GetCommentsByUserIdQueryHandler : IRequestHandler<GetCommentsByUserIdQuery, List<Comment>>
    {
        private readonly IJsonPlaceholderClient _placeholderClient;
        public GetCommentsByUserIdQueryHandler(IJsonPlaceholderClient jsonPlaceholderClient)
        {
            _placeholderClient = jsonPlaceholderClient;
        }

        public async Task<List<Comment>> Handle(GetCommentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _placeholderClient.GetCommentsByUserIdAsync(request.UserId);
            return comments;
        }
    }
}
