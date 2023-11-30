using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Application.Features.Users.Queries.GetUserList;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdIncludeUserProfile(request.id);

            GetUserDto userToReturn = new GetUserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                IsActive = user.IsActive,
                UserProfileDto = new GetUserProfileDto()
                {
                    UserProfileId = user.UserProfile.UserProfileId,
                    UserId = user.UserProfile.UserId,
                    FirstName = user.UserProfile.FirstName,
                    LastName = user.UserProfile.LastName,
                    PersonalNumber = user.UserProfile.PersonalNumber
                }
            };

            return userToReturn;
            
        }
    }
}
