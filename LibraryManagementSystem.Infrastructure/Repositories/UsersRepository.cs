using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region CONSTANTES
        const string GET_USERS = "SP_GET_USERS";
        const string GET_USER_BY_ID = "SP_GET_USER_BY_ID";
        const string UPDATE_USER = "SP_UPDATE_USER";
        const string CREATE_USER = "SP_CREATE_USER";
        const string DELETE_USER = "SP_DELETE_USER";
        #endregion

        public void CreateUser(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
