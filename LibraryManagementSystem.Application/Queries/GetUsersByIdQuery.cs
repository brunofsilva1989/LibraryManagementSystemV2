using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
