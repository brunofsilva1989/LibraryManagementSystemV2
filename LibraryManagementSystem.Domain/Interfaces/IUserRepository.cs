using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(UserModel model);
        void DeleteUser(int id);
        void UpdateUser(UserModel model);
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetAllUsers();
    }
}
