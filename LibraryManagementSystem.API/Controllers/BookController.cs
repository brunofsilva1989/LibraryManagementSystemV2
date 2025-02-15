using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Domain.Exceptions;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {

        private readonly CreateBookCommand _createBookCommand;  
        private readonly GetBooksQuery _getBooksQuery;
        private readonly GetBookByIdQuery _getBookByIdQuery;
        private readonly UpdateBookCommand _updateBookCommand;
        private readonly DeleteBookCommand _deleteBookCommand;

        public BookController(CreateBookCommand createBookCommand, GetBooksQuery getBooksQuery, GetBookByIdQuery getBookByIdQuery, UpdateBookCommand updateBookCommand, DeleteBookCommand deleteBookCommand)
        {
            _createBookCommand = createBookCommand;
            _getBooksQuery = getBooksQuery;
            _getBookByIdQuery = getBookByIdQuery;
            _updateBookCommand = updateBookCommand;
            _deleteBookCommand = deleteBookCommand;
        }

        /// <summary>
        /// Método para buscar todos os livros.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-books")]        
        public IActionResult GetBooks()
        {
            var books = _getBooksQuery.Execute();
            
            if (books == null)
            {
                return NotFound("Book not found!");
            }

            return Ok(books);
        }

        /// <summary>
        /// Método para buscar um livro por seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid book Id"); //Retorna Erro 404 Bad Request
            }

            var book = _getBookByIdQuery.Execute(id);
            
            if (book == null) 
            {
                return NotFound($"Book with Id {id} not found!"); //Retorna erro 404 Not Found
            }

            return Ok(book);
        }

        /// <summary>
        /// Método para criar um livro.
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-book")]
        public IActionResult CreateBook(BookDto bookModel)
        {
            var book = new BookModel
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                ISBN = bookModel.ISBN,
                YearPublication = bookModel.YearPublication
            };

            _createBookCommand.Execute(book);

            if (book != null) 
            {
                return Ok("Livro gravado com sucesso!");
            }
           
            return Ok(bookModel);
        }

        /// <summary>
        /// Método para atualizar um livro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("update-book")]
        public IActionResult UpdateBook(BookModel book) 
        {
            _updateBookCommand.Execute(book);
            return Ok("Book updated successfully!");
        }

        /// <summary>
        /// Método para deletar um livro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-book/{bookId}")]
        public IActionResult DeleteBook(int bookId) 
        {
            _deleteBookCommand.Execute(bookId);
            return Ok("Book deleted successfully!");
        }
    }
}
