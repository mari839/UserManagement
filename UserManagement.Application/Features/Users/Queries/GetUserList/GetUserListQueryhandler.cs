using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryhandler : IRequestHandler<GetUserListQuery, List<GetUserListDto>>
    {
        private readonly IUserRepository userRepository;

        public GetUserListQueryhandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<List<GetUserListDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllUsersIncludeUserProfile();
            List<GetUserListDto> UserListToReturn = new List<GetUserListDto>();
            foreach (var user in users)
            {
                GetUserListDto userToReturn = new GetUserListDto()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    UserProfileDto = new GetUserListProfileDto()
                    {
                        UserProfileId = user.UserProfile.UserProfileId,
                        UserId = user.UserProfile.UserId,
                        FirstName = user.UserProfile.FirstName,
                        LastName = user.UserProfile.LastName,
                        PersonalNumber = user.UserProfile.PersonalNumber
                    }
                };
                UserListToReturn.Add(userToReturn);
            }
            return UserListToReturn;
        }
    }
}
