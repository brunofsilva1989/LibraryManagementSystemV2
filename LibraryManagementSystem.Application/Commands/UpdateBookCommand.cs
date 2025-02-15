using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class UpdateBookCommand
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommand(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(BookModel bookModel) => _bookRepository.UpdateBook(bookModel);

    }
}
