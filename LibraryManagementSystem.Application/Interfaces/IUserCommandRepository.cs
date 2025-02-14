using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IUserCommandRepository
    {
        void CreateUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
    }
}
