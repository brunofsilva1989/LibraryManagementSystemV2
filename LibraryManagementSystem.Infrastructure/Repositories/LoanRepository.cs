using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using static LibraryManagementSystem.Domain.Enum.LoanEnums;

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
        const string CREATE_LOAN = "SP_CREATE_LOAN";
        const string DELETE_LOAN = "SP_DELETE_LOAN";
        const string UPDATE_LOAN = "SP_UPDATE_LOAN";
        const string GET_LOAN_BY_USER = "SP_GET_LOAN_BY_USER";
        const string MARK_LOAN_LATE = "SP_MARK_LOAN_LATE";
        const string RENEW_LOAN = "SP_RENEW_LOAN";
        const string RETURN_LOAN = "SP_RETURN_LOAN";
        #endregion

        public void CreateLoan(int idUser, int idBook)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(CREATE_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    command.Parameters.AddWithValue("@IdBook",idBook);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteLoan(int loanId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(DELETE_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", loanId);
                    command.ExecuteNonQuery();
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
                    command.Parameters.AddWithValue("@UserId", model.IdUser);
                    command.Parameters.AddWithValue("@BookId", model.IdBook);
                    command.Parameters.AddWithValue("@LoanDate", model.LoanDate);
                    command.Parameters.AddWithValue("@ReturnDate", model.ReturnDate);
                    command.Parameters.AddWithValue("@Status", model.Status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public LoanModel GetLoanByUser(int idUser)
        {
            LoanModel loan = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(GET_LOAN_BY_USER, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loan = new LoanModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdUser = Convert.ToInt32(reader["IdUser"]),
                                IdBook = Convert.ToInt32(reader["IdBook"]),
                                LoanDate = Convert.ToDateTime(reader["LoanDate"]),
                                ReturnDate = Convert.ToDateTime(reader["ReturnDate"]),
                                Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), reader["Status"].ToString())
                            };                            
                        }
                    }
                }
            }
            return loan;
        }

        public void MarkLoanLate()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(MARK_LOAN_LATE, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RenewLoan(int loanId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(RENEW_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", loanId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ReturnLoan(int loanId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(RETURN_LOAN, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", loanId);
                    command.ExecuteNonQuery();
                }
            }
        }        
    }
}
