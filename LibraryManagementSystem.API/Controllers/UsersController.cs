using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Services;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : Controller
    {
        
        private readonly GetUsersUseCase _getUsersUseCase;

        public UsersController(IUserRepository userRepository, GetUsersUseCase getUsersUseCase)
        {
            _getUsersUseCase = getUsersUseCase;            
        }


        /// <summary>
        /// Método para buscar todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _getUsersUseCase.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        /// <summary>
        /// Método para buscar um usuário por seu id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _getUsersUseCase.GetUserById(id);

            if (user == null)
            {
                return NotFound("User not found");
            }
            
            return Ok(user);
        }

        /// <summary>
        /// Método para criar um novo usuário.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(UsersDto usersDto) 
        {
            var user = new UsersDto
            {
                Name = usersDto.Name,
                CPF = usersDto.CPF,
                Email = usersDto.Email,
                Password = usersDto.Password,
                CreationDate = usersDto.CreationDate,
                UpdateDate = usersDto.UpdateDate,
            };

            return Ok(user);
        }

        /// <summary>
        /// Método para atualizar um usuário
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateUser(int id) 
        {
            var user = _getUsersUseCase.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _getUsersUseCase.UpdateUser(user);

            return Ok(user);
        }

        /// <summary>
        /// Método para deletar um usuário com base num id.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteUser(int id) 
        {
            var user = _getUsersUseCase.GetUserById(id);

            if (user == null)
            {
                return NotFound("User not found!");
            }

            _getUsersUseCase.DeleteUser(user.Id);

            return Ok(id);
        }

    }
}
