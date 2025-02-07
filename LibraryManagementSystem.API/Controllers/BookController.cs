using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Esté método busca todos os livros cadastrados no banco.
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get()
        {
            var books = _bookService.GetBooks();

            if (books == null) 
            {
                return NotFound();
            }

            return Ok(books);
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
        public IActionResult CreateBook(BookModel model)
        {
            _bookService.CreateBook(model);

            if (model != null) 
            {
                return BadRequest();
            }
           
            return Ok(model);
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
