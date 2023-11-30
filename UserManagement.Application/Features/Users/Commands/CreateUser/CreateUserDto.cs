using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public CreateUserProfileDto UserProfileDto { get; set; }
    }
}
