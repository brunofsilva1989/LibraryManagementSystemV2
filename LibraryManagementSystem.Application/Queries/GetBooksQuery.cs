using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries
{
    public class GetBooksQuery
    {
        private readonly IBookRepository _bookRepository;
        public GetBooksQuery(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository; 
        }

        public IEnumerable<BookModel> Execute() => _bookRepository.GetBooks();
    }
}
