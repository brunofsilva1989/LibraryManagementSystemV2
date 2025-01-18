using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanController : Controller
    {

        /// <summary>
        /// Método para buscar todos os empréstimos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllLoans()
        {
            return Ok("Endpoint OK");
        }

        /// <summary>
        /// Método para buscar um empréstimo com base num id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(id);
        }

        /// <summary>
        /// Método para criar um novo empréstimo.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateLoan() 
        {
            return BadRequest();
        }

        /// <summary>
        /// Método para atualizar um empréstimo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateLoan(int id) 
        {
            return Ok(id);
        }

        /// <summary>
        /// Método para deletar um empréstimo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteLoan(int id)
        {
            return Ok(id);
        }

    }
}
