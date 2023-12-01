using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPhotosByUserId
{
    public class GetPhotosByUserIdQueryHandler : IRequestHandler<GetPhotosByUserIdQuery, List<Photo>>
    {
        private readonly IJsonPlaceholderClient _placeholderClient;
        public GetPhotosByUserIdQueryHandler(IJsonPlaceholderClient jsonPlaceholderClient)
        {
            _placeholderClient = jsonPlaceholderClient;
        }
        public async Task<List<Photo>> Handle(GetPhotosByUserIdQuery request, CancellationToken cancellationToken)
        {
            var photos = await _placeholderClient.GetPhotosByUserIdAsync(request.UserId);
            return photos;
        }
    }
}
