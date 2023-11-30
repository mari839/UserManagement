using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.Users.Commands.CreateUser;

namespace UserManagement.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UpdateUserProfileDto UserProfileDto { get; set; }
    }
}
