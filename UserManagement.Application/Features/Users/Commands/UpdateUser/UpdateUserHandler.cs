using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Features.Users.Commands.CreateUser;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UpdateUserDto userToReturn = new UpdateUserDto()
            {
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                UserProfileDto = new UpdateUserProfileDto()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PersonalNumber = request.PersonalNumber
                }
            };

            User user = new User();
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;

            user.UserProfile = new UserProfile();
            user.UserProfile.FirstName = request.FirstName;
            user.UserProfile.LastName = request.LastName;
            user.UserProfile.PersonalNumber = request.PersonalNumber;

            await _userRepository.UpdateUserProfileAsync(user);
            return userToReturn;
        }
    }
}
