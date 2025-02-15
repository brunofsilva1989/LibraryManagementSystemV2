using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;


namespace LibraryManagementSystem.Application.Queries
{
    public class GetUsersQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> Execute() => _userRepository.GetUsers();

        //sobrecarga para passar id como parametro
        public UserModel Execute(int id) => _userRepository.GetUserById(id);


    }
}
