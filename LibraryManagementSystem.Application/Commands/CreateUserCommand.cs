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
    public class CreateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(UserModel user) => _userRepository.CreateUser(user);

        //sobrecarga para passar o id e model juntos
        public void Execute(int id, UserModel user)
        {
            user.Id = id;
            _userRepository.CreateUser(user);
        }

    }
}
