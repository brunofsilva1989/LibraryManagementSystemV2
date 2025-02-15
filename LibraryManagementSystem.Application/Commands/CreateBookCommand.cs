using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class CreateBookCommand
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommand(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(BookModel bookModel) => _bookRepository.CreateBook(bookModel);
        
        public void Execute(int id, BookModel bookModel)
        {
            bookModel.Id = id;
            _bookRepository.CreateBook(bookModel);
        }
    }
}
