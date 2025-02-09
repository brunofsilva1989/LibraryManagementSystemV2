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
        public void UpdateBook(BookDto bookDto);
        public void DeleteBook(int id);
        public void GetById(int id);
        IEnumerable<BookDto> GetBooks();
    }
}
