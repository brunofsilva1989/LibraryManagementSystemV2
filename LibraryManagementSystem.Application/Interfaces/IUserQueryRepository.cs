using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IUserQueryRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserById(int id);
    }
}
