using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Users.Queries.GetUserList;

namespace UserManagement.Application.Features.Users.Queries.GetUser
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public GetUserProfileDto UserProfileDto { get; set; }
    }
}
