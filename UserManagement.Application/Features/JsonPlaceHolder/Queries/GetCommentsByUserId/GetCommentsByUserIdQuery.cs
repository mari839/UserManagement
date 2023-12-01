using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Services.Models;

namespace UserManagement.Application.Features.JsonPlaceHolder.Queries.GetCommentsByUserId
{
    public class GetCommentsByUserIdQuery : IRequest<List<Comment>>
    {
        public int UserId { get; set; }
    }
}
