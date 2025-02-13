using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services
{
    public class GetBookUseCase : IBookRepository
    {
        private readonly IBookRepository _bookRepository;

        public GetBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Create book in the Use Case
        /// </summary>
        /// <param name="model"></param>
        public void CreateBook(BookModel model)
        {
            var book = new BookModel
            {                
                Title = model.Title,
                Author = model.Author,
                ISBN = model.ISBN,
                YearPublication = model.YearPublication
            };

            _bookRepository.CreateBook(book);
        }

        /// <summary>
        /// Delete book in the Use Case
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
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
        /// Get all books in the Use Case
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookModel> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return books.Select(book => new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                YearPublication = book.YearPublication
            });
        }

        /// <summary>
        /// Get book by id in the Use Case
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookModel GetById(int id)
        {
            var book = new BookModel();

            book = _bookRepository.GetById(id);

            if (book == null)
            {
                return null;
            }

            return new BookModel
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                YearPublication = book.YearPublication
            };
        }

        /// <summary>
        /// Update book in the Use Case
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateBook(BookModel model)
        {            
            var book = new BookModel
            {
                Title = model.Title,
                Author = model.Author,
                ISBN = model.ISBN,
                YearPublication = model.YearPublication
            };

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            _bookRepository.UpdateBook(book);
        }
    }
}
