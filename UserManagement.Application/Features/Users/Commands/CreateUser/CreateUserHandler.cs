using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User();
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;
            
            user.UserProfile = new UserProfile();
            user.UserProfile.FirstName = request.FirstName;
            user.UserProfile.LastName = request.LastName;
            user.UserProfile.PersonalNumber = request.PersonalNumber;

            var res = await _userRepository.AddUserAsync(user);
            return res;
        }
    }
}
