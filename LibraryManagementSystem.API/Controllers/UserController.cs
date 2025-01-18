using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        /// <summary>
        /// Método para buscar todos os usuários.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return NoContent();
        }

        /// <summary>
        /// Método para buscar um usuário por seu id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok(id);
        }

        /// <summary>
        /// Método para criar um novo usuário.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser() 
        {
            return NoContent();
        }

        /// <summary>
        /// Método para atualizar um usuário
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateUser(int id) 
        {
            return Ok(id);
        }

        /// <summary>
        /// Método para deletar um usuário com base num id.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteUser(int id) 
        {
            return Ok(id);
        }

    }
}
