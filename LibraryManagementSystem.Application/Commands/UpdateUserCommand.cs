using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class UpdateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommand(IUserRepository userCommandRepository)
        {
            _userRepository = userCommandRepository;
        }

        public void Execute(UserModel user) => _userRepository.UpdateUser(user);

    }
}
