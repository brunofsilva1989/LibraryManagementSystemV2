using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        
        /// <summary>
        /// Esté método busca todos os livros cadastrados no banco.
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Esté método busca o livro com base no id passado como parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(id);
        }

        /// <summary>
        /// Este método cria um novo registro de um livro no banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateBook()
        {
            return BadRequest();
        }

        /// <summary>
        /// Este método atualiza o registrio de um livro com base no id passado como parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateBook(int id) 
        {
            return Ok(id);
        }

        /// <summary>
        /// Esté método remove um livro da base, passano o id específico como parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteBook(int id) 
        {
            return BadRequest();
        }
    }
}
