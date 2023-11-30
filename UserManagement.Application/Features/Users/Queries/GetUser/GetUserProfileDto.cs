using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Features.Users.Queries.GetUser
{
    public class GetUserProfileDto
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalNumber { get; set; }
        public int UserId { get; set; }
    }
}
