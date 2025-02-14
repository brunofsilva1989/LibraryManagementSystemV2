using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class DeleteUserCommand
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(int id) => _userRepository.DeleteUser(id);
    }
}
