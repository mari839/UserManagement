using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string PersonalNumber { get; set; }
        public virtual User User { get; set; }
    }
}
