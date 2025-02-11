using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Services;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        
        private readonly IBookRepository _bookService;
        private readonly GetBookUseCase _getBookUseCase;

        public BookController(IBookRepository bookService, GetBookUseCase getBookUseCase)
        {
            _bookService = bookService;
            _getBookUseCase = getBookUseCase;
        }

        /// <summary>
        /// Esté método busca todos os livros cadastrados no banco.
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get()
        {
            var books = _getBookUseCase.GetBooks();

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
            //trazer o livro pelo id
            var book = _getBookUseCase.GetById(id);
            if (book == null) {
                return NotFound();                    
            }

            return Ok(book);
        }

        /// <summary>
        /// Este método cria um novo registro de um livro no banco de dados.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateBook(BookDto modelDto)
        {
            var bookModel = new BookModel
            {
                Title = modelDto.Title,
                Author = modelDto.Author,
                ISBN = modelDto.ISBN,
                YearPublication = modelDto.YearPublication
            };

            _getBookUseCase.CreateBook(bookModel);

            if (modelDto != null) 
            {
                return Ok("Livro gravado com sucesso!");
            }
           
            return Ok(modelDto);
        }

        /// <summary>
        /// Este método atualiza o registrio de um livro com base no id passado como parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateBook(int id) 
        {
            //trazer os campos do livro para atualizar
            var book = _getBookUseCase.GetById(id);

            if (book == null) {
                return NotFound();
            }

            _getBookUseCase.UpdateBook(book);

            return Ok(book);
        }

        /// <summary>
        /// Esté método remove um livro da base, passano o id específico como parâmetro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteBook(int id) 
        {
            var book = _getBookUseCase.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _getBookUseCase.DeleteBook(id);

            return NoContent();
        }
    }
}
