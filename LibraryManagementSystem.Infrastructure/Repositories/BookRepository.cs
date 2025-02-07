using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository : IBookService
    {
        #region Propriedades Privadas
        private readonly LibraryDbContext _connectionString;
        #endregion

        public BookRepository(LibraryDbContext connectionString)
        {
            _connectionString = connectionString;
        }

        #region CONSTANTES
        const string GET_BOOKS = "SP_GETALL_BOOKS";
        const string CREATE_BOOK = "SP_CREATE_BOOK";
        #endregion
       
        public void UpdateBook()
        {
            throw new NotImplementedException();
        }

        public void DeleteBook()
        {
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var books = new List<BookModel>();

            //criar o acesso ADO.NET a procedure SP_GETALL_BOOKS
            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GET_BOOKS, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           books.Add(new BookModel
                           {
                               Id = reader.GetInt32(0),
                               Title = reader.GetString(1),
                               Author = reader.GetString(2),
                               ISBN = reader.GetString(3),
                               YearPublication = reader.GetInt32(4)
                           });
                        }
                    }
                }
            }

            return null;
        }

        public void CreateBook(BookModel model)
        {
            var books = new BookModel();

            //criar o acesso ADO.NET a procedure SP_CREATE_BOOK
            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(CREATE_BOOK, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", books.Title);
                    command.Parameters.AddWithValue("@Author", books.Author);
                    command.Parameters.AddWithValue("@ISBN", books.ISBN);
                    command.Parameters.AddWithValue("@YearPublication", books.YearPublication);
                    command.ExecuteNonQuery();
                }
            }            
        }
    }
}
