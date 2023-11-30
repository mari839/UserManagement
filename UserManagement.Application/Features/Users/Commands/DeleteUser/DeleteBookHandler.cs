using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Contracts;

namespace UserManagement.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IUserRepository _userRepository;
        public DeleteBookHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            if(user == null)
            {
                return;
            }
            else
            {
                _userRepository.DeleteUserAsync(request.Id);
            }
        }
    }
}
