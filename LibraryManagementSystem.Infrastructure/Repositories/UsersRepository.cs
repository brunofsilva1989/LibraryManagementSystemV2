using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UsersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region CONSTANTES
        const string GET_USERS = "SP_GET_USERS";
        const string GET_USER_BY_ID = "SP_GET_USER_BY_ID";
        const string UPDATE_USER = "SP_UPDATE_USER";
        const string CREATE_USER = "SP_CREATE_USER";
        const string DELETE_USER = "SP_DELETE_USER";
        #endregion

        /// <summary>
        /// Create user in the Base
        /// </summary>
        /// <param name="model"></param>
        public void CreateUser(UserModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(CREATE_USER, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CPF", model.CPF);
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Delete user in the Base
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(DELETE_USER, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get all users in the Base
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> GetUsers()
        {
            var users = new List<UserModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(GET_USERS, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            var user = new UserModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CPF = reader["CPF"].ToString(),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                CreationDate = reader["CreationDate"] != DBNull.Value ? (DateTime)reader["CreationDate"] : default(DateTime),
                                UpdateDate = reader["UpdateDate"] != DBNull.Value ? (DateTime?)reader["UpdateDate"] : null
                            };                                                       
                            users.Add(user);
                        }
                        
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Get user by id in the Base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(int id)
        {
            UserModel user = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(GET_USER_BY_ID, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                CPF = reader["CPF"].ToString(),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                CreationDate = reader["CreationDate"] != DBNull.Value ? (DateTime)reader["CreationDate"] : default(DateTime),
                                UpdateDate = reader["UpdateDate"] != DBNull.Value ? (DateTime?)reader["UpdateDate"] : null
                            };
                        }
                       
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// Update user in the Base
        /// </summary>
        /// <param name="model"></param>
        public void UpdateUser(UserModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(UPDATE_USER, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@CPF", model.CPF);
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
