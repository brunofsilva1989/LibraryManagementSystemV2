using LibraryManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class DeleteBookCommand
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommand(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Execute(int bookId) => _bookRepository.DeleteBook(bookId);
    }
}
