using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult CreateBook([FromBody] BookDto bookDto)
        {
            var book = new BookModel
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                YearPublication = bookDto.YearPublication
            };
            
            if (_getBookByIdQuery.Execute(book.Id) != null)
            {
                throw new DbUpdateException("Book already exists!");
            }

            _createBookCommand.Execute(book);

            if (book != null) 
            {
                return Ok("Livro gravado com sucesso!");
            }
           
            return Ok(bookDto);
        }

        /// <summary>
        /// Método para atualizar um livro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook([FromBody] BookDto bookDto) 
        {
            if (bookDto == null)
            {
                throw new NotFoundException("Book not found!");
            }

            var book = new BookModel
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                YearPublication = bookDto.YearPublication
            };

            _updateBookCommand.Execute(bookDto);
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
            if (bookId <= 0)
            {
                throw new NotFoundException("Book not found!");
            }

            _deleteBookCommand.Execute(bookId);
            return Ok("Book deleted successfully!");
        }
    }
}
