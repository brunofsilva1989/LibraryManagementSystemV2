using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository : IBookService
    {
        #region Propriedades Privadas
        private readonly LibraryDbContext _connectionString;
        private readonly BookModel _model;
        #endregion

        public BookRepository(LibraryDbContext connectionString, BookModel model)
        {
            _connectionString = connectionString;
            _model = model;
        }

        #region CONSTANTES
        const string GET_BOOKS = "SP_BOOKS";
        const string CREATE_BOOK = "SP_CREATE_BOOKS";
        #endregion
       
        public int UpdateBook(BookModel id)
        {
            throw new NotImplementedException();
        }

        public int DeleteBook(BookModel id)
        {
            throw new NotImplementedException();
        }

        public int GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> GetBooks()
        {
            var books = new List<BookModel>();

            //criar o acesso ADO.NET a procedure SP_BOOKS
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
                            var book = new BookModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                YearPublication = Convert.ToInt32(reader["YearPublication"])
                            };
                            books.Add(book);
                        }
                    }
                }
            }

            return books;
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
    }
}
