using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;

namespace LibraryManagementSystem.Application.Queries
{
    public class GetUsersByIdQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUsersByIdQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Execute(int id) => _userRepository.GetUserById(id);
    }
}
