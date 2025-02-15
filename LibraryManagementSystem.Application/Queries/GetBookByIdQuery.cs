using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries
{
    public class GetBookByIdQuery
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQuery(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public BookModel Execute(int id) => _bookRepository.GetBookById(id);
    }
}
