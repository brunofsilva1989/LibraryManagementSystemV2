using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Repositories;

namespace LibraryManagementSystem.Application.Services
{
    public class BookService : IBookService
    {

        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="bookDto"></param>
        public void CreateBook(BookDto bookDto)
        {
            var book = new BookModel
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                YearPublication = bookDto.YearPublication
            };

            _bookRepository.CreateBook(book);
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteBook(int id)
        {
            //delete book
            var book = _bookRepository.GetById(id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            _bookRepository.DeleteBook(book.Id);

        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookDto> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return books.Select(book => new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                YearPublication = book.YearPublication
            });
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookDto GetById(int id)
        {
            var book = new BookModel();

            book = _bookRepository.GetById(id);

            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                YearPublication = book.YearPublication
            };
        }
    }
}
