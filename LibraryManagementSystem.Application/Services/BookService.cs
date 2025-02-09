using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book != null)
            {
                _bookRepository.DeleteBook(book);
            }

            return book;
        }

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

        public void UpdateBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }

        void IBookService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
