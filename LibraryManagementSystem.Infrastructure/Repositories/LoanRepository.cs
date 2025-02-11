using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void DeleteLoan(LoanModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoanModel> GetAllLoans()
        {
            throw new NotImplementedException();
        }

        public LoanModel GetLoanById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLoan(LoanModel model)
        {
            throw new NotImplementedException();
        }
    }
}
