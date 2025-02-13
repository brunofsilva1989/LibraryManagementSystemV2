using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services
{
    public class GetUsersUseCase : IUserRepository
    {        
        private readonly IUserRepository _userRepository;

        public GetUsersUseCase(IUserRepository userRepository) 
        {
            _userRepository = userRepository;     
        }

        /// <summary>
        /// Create in the Use Case
        /// </summary>
        /// <param name="model"></param>
        public void CreateUser(UserModel model)
        {
            var user = new UserModel
            {
                Name = model.Name,
                CPF = model.CPF,
                Email = model.Email,
                Password = model.Password,
                CreationDate = model.CreationDate,
                UpdateDate = model.UpdateDate,
            };

            _userRepository.CreateUser(user);
        }


        /// <summary>
        /// Delete in the Use Case
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteUser(int id)
        {            
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new Exception("Book not found");
            }

            _userRepository.DeleteUser(user.Id);

        }

        /// <summary>
        /// Get all users in the Use Case
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.Select(user => new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                CPF = user.CPF,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                UpdateDate = user.UpdateDate,
            });
        }

        /// <summary>
        /// Get user by id in the Use Case
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(int id)
        {
            var user = new UserModel();

            user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            return new UserModel
            {
                Name = user.Name,
                CPF = user.CPF,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                UpdateDate = user.UpdateDate
            };
        }

        /// <summary>
        /// Update in the Use Case
        /// </summary>
        /// <param name="model"></param>
        public void UpdateUser(UserModel model)
        {
            var user = new UserModel
            {
                Name = model.Name,
                CPF = model.CPF,
                Email = model.Email,
                Password = model.Password,
                CreationDate = model.CreationDate,
                UpdateDate = model.UpdateDate,
            };

            _userRepository.UpdateUser(user);
        }
    }
}


