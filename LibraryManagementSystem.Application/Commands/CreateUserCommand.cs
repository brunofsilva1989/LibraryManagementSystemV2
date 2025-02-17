using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;

namespace LibraryManagementSystem.Application.Commands
{
    public class CreateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(UsersDto userDto)
        {
            var userModel = new UserModel
            {                
                CPF = userDto.CPF,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
        
        public void Execute(int id, UserModel user)
        {
            user.Id = id;
            _userRepository.CreateUser(user);
        }

    }
}
