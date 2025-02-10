using LibraryManagementSystem.Domain.Model;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IBookService
    {
        public void CreateBook(BookModel model);
        public void UpdateBook(int id);
        public void DeleteBook(int id);
        public BookModel GetById(int id);
        IEnumerable<BookModel> GetBooks();
    }
}
