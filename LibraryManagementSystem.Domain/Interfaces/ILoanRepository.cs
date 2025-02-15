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
        void CreateLoan(int userId, int bookId);
        void DeleteLoan(int loanId);
        void UpdateLoan(LoanModel model);
        LoanModel GetLoanByUser(int userId);
        void MarkLoanLate();
        void RenewLoan(int loanId);
        void ReturnLoan(int loanId);        
    }
}
