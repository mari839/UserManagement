using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserById(request.id);
            
                return user;
            
        }
    }
}
