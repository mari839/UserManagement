using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    public class UserProfile 
    {
        public int UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        [MaxLength(11)]
        [MinLength(11)]
        public long PersonalNumber { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
