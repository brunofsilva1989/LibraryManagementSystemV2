using LibraryManagementSystem.Domain.Model;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        #region Propriedades Privadas
        private readonly string _connectionString;
        
        #endregion

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");           
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(CREATE_BOOK, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", model.Title);
                    command.Parameters.AddWithValue("@Author", model.Author);
                    command.Parameters.AddWithValue("@ISBN", model.ISBN);
                    command.Parameters.AddWithValue("@YearPublication", model.YearPublication);
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
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
        public void UpdateBook(BookModel book)
        {            
            using (SqlConnection connection = new SqlConnection(_connectionString))
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
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
