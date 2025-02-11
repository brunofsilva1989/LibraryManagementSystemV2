using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Interfaces
{
    public interface ILoanRepository
    {
        void CreateLoan(LoanModel model);
        void DeleteLoan(LoanModel model);
        void UpdateLoan(LoanModel model);
        LoanModel GetLoanById(int id);
        IEnumerable<LoanModel> GetAllLoans();

    }
}
