using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IBookService
    {
        public void CreateBook(BookModel model);
        public void UpdateBook();
        public void DeleteBook();
        public void GetById();
        IEnumerable<BookModel> GetBooks();
    }
}
