using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdQuery : IRequest<List<Post>>
    {
        public int UserId { get; set; }
    }
}
