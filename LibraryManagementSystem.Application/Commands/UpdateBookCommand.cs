using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;

namespace LibraryManagementSystem.Application.Commands
{
    public class UpdateBookCommand
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommand(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(BookDto bookDto)
        {
            var bookModel = new BookModel
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                YearPublication = bookDto.YearPublication
            };

            _bookRepository.UpdateBook(bookModel);
        }

    }
}
