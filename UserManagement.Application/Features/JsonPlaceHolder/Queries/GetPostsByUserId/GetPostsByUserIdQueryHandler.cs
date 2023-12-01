using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, List<Post>>
    {
        private readonly IJsonPlaceholderClient _placeholderClient;
        public GetPostsByUserIdQueryHandler(IJsonPlaceholderClient jsonPlaceholderClient)
        {
            _placeholderClient = jsonPlaceholderClient;
        }

        public async Task<List<Post>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var posts = await _placeholderClient.GetPostsByUserIdAsync(request.UserId);
            return posts;
        }
    }
}
