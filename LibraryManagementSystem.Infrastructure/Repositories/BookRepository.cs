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
        private readonly BookModel _model;
        #endregion

        public BookRepository(LibraryDbContext connectionString, BookModel model)
        {
            _connectionString = connectionString;
            _model = model;
        }

        #region CONSTANTES
        const string GET_BOOKS = "SP_GET_BOOKS";
        const string GET_BOOK_BY_ID = "SP_GET_BOOK_BY_ID";
        const string UPDATE_BOOK = "SP_UPDATE_BOOKS";
        const string CREATE_BOOK = "SP_CREATE_BOOKS";
        const string DELETE_BOOK = "SP_DELETE_BOOKS";

        #endregion

        /// <summary>
        /// Create a new book in the database
        /// </summary>
        /// <param name="model"></param>
        public void CreateBook(BookModel model)
        {
            var books = new BookModel();

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

        /// <summary>
        /// Get all books from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookModel> GetBooks()
        {
            var books = new List<BookModel>();
            
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

        /// <summary>
        /// Get a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookModel GetById(int id)
        {
            BookModel book = null;

            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(GET_BOOK_BY_ID, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book = new BookModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                YearPublication = Convert.ToInt32(reader["YearPublication"])
                            };
                        }
                    }
                }
            }
            return book;
        }

        /// <summary>
        /// Update a book in the database
        /// </summary>
        /// <param name="id"></param>
        public void UpdateBook(int id)
        {
            var book = new BookModel();

            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(UPDATE_BOOK, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@YearPublication", book.YearPublication);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Delete a book from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id)
        {            

            using (SqlConnection connection = new SqlConnection(_connectionString.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(DELETE_BOOK, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
}
