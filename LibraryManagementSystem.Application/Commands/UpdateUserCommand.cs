using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;

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
