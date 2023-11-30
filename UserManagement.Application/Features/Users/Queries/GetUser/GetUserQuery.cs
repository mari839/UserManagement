using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<User>
    {
        public int id { get; set; }
    }
}
