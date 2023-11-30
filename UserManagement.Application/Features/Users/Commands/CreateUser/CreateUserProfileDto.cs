using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalNumber { get; set; }
    }
}
