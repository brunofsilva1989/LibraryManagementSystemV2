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

        public void UpdateBook(BookModel book)
        {
            //atualizar o livro
            _bookRepository.UpdateBook(book);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            _bookRepository.UpdateBook(book);

        }
    }
}
