using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.DTOs;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IBookService
    {
        public void CreateBook(BookDto bookDto);
        public int UpdateBook(BookDto bookDto);
        public int DeleteBook(int id);
        public int GetById(int id);
        IEnumerable<BookDto> GetBooks();
    }
}
