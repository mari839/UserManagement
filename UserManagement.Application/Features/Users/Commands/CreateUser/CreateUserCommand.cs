using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public CreateUserCommand(string userName, string password, string email, string firstName, string lastName, long personalNumber)
        {
            UserName = userName;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalNumber { get; set; }
    }
}
