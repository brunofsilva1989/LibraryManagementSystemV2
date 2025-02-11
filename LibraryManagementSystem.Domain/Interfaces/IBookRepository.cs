using LibraryManagementSystem.Domain.Model;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface IBookRepository
    {
        void CreateBook(BookModel model);
        void UpdateBook(BookModel model);
        void DeleteBook(int id);
        BookModel GetById(int id);
        IEnumerable<BookModel> GetBooks();
    }
}
