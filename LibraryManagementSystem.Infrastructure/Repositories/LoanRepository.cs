using LibraryManagementSystem.Domain.Enum;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly string _connectionString;

        public LoanRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region CONSTANTES
        const string GET_LOANS = "SP_GET_LOAN";
        const string GET_LOAN_BY_ID = "SP_GET_LOAN_BY_ID";
        const string UPDATE_LOAN = "SP_UPDATE_LOAN";
        const string CREATE_LOAN = "SP_CREATE_LOAN";
        const string DOWN_LOAN = "SP_DOWN_LOAN";
        #endregion

        public void CreateLoan(LoanModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(CREATE_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUser", model.IdUser);
                    command.Parameters.AddWithValue("@IdBook", model.IdBook);
                    command.Parameters.AddWithValue("@LoanDate", model.LoanDate);
                    command.Parameters.AddWithValue("@ReturnDate", model.ReturnDate);
                    command.ExecuteNonQuery();
                }
            }

        }

        public void DeleteLoan(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(DOWN_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<LoanModel> GetAllLoans()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(GET_LOANS, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        var loans = new List<LoanModel>();
                        while (reader.Read())
                        {
                            loans.Add(new LoanModel
                            {
                                Id = (int)reader["Id"],
                                IdUser = (int)reader["IdUser"],
                                IdBook = (int)reader["IdBook"],
                                LoanDate = (DateTime)reader["LoanDate"],
                                ReturnDate = (DateTime)reader["ReturnDate"],
                                Status = (LoanEnums.LoanStatus)Enum.Parse(typeof(LoanEnums.LoanStatus), reader["Status"].ToString())
                            });
                        }
                        return loans;
                    }
                }
            }
        }

        public LoanModel GetLoanById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(GET_LOAN_BY_ID, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new LoanModel
                            {
                                Id = (int)reader["Id"],
                                IdUser = (int)reader["IdUser"],
                                IdBook = (int)reader["IdBook"],
                                LoanDate = (DateTime)reader["LoanDate"],
                                ReturnDate = (DateTime)reader["ReturnDate"],
                                Status = (LoanEnums.LoanStatus)Enum.Parse(typeof(LoanEnums.LoanStatus), reader["Status"].ToString())
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void UpdateLoan(LoanModel model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(UPDATE_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@IdUser", model.IdUser);
                    command.Parameters.AddWithValue("@IdBook", model.IdBook);
                    command.Parameters.AddWithValue("@LoanDate", model.LoanDate);
                    command.Parameters.AddWithValue("@ReturnDate", model.ReturnDate);
                    command.Parameters.AddWithValue("@Status", model.Status);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
