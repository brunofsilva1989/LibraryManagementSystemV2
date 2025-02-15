using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Domain.Exceptions;
using LibraryManagementSystem.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : Controller
    {

        private readonly GetUsersQuery _getUsersQuery;
        private readonly GetUsersByIdQuery _getUsersByIdQuery;
        private readonly CreateUserCommand _createUserCommand;
        private readonly UpdateUserCommand _updateUserCommand;
        private readonly DeleteUserCommand _deleteUserCommand;


        public UsersController(GetUsersQuery getUsersQuery, GetUsersByIdQuery getUsersByIdQuery, CreateUserCommand createUserCommand, UpdateUserCommand updateUserCommand, DeleteUserCommand deleteUserCommand)
        {
            _createUserCommand = createUserCommand;
            _getUsersQuery = getUsersQuery;
            _getUsersByIdQuery = getUsersByIdQuery;
            _updateUserCommand = updateUserCommand;
            _deleteUserCommand = deleteUserCommand;
        }

        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new Exception("Isso é um erro de teste!");
        }

        /// <summary>
        /// Método para buscar todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-users")]
        public IActionResult Get()
        {
            var users = _getUsersQuery.Execute();

            if (users == null)
            {
                throw new NotFoundException($"User not found in the Base!");
            }

            return Ok(users);
        }

        /// <summary>
        /// Método para buscar um usuário por seu id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-users/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _getUsersByIdQuery.Execute(id);

            if (user == null)
            {
                throw new NotFoundException($"User with Id {id} not found!");
            }

            return Ok(user);
        }

        /// <summary>
        /// Método para criar um novo usuário.
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-user")]
        public IActionResult CreateUser(UserModel user)
        {
            _createUserCommand.Execute(user);

            return Ok(user);
        }

        /// <summary>
        /// Método para atualizar um usuário
        /// </summary>
        /// <returns></returns>
        [HttpPut("update-user/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user) 
        {
            //nõa tera mais use case só o padrao cqrs
            var existingUser = _getUsersQuery.Execute(id);
            if (existingUser == null)
            {
                return NotFound("User not found!");
            }

            _createUserCommand.Execute(id, user);
            return Ok("user Updated successfully!");
        }

        /// <summary>
        /// Método para deletar um usuário com base num id.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete-user")]
        public IActionResult DeleteUser(int id) 
        {
            _deleteUserCommand.Execute(id);
          
            return Ok("User deleted!");
        }

    }
}
