using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Services
{
    public class GetLoansUseCase : ILoanRepository
    {        
        private readonly ILoanRepository _loanRepository;

        public GetLoansUseCase(ILoanRepository loanRepository) 
        {
            _loanRepository = loanRepository;            
        }

        public void CreateLoan(LoanModel model)
        {
            var loan = new LoanModel
            {
                IdUser = model.IdUser,
                IdBook = model.IdBook,
                Loans = model.Loans,
                LoanDate = model.LoanDate,
                ReturnDate = model.ReturnDate,
                Status = model.Status,
            };

            _loanRepository.CreateLoan(loan);
        }

        public void DeleteLoan(int id)
        {
            var loan = _loanRepository.GetLoanById(id);

            if (loan == null)
            {
                throw new Exception("Book not found");
            }

            _loanRepository.DeleteLoan(loan.Id);
        }

        public IEnumerable<LoanModel> GetAllLoans()
        {
            var loan = _loanRepository.GetAllLoans();

            return loan;
        }

        public LoanModel GetLoanById(int id)
        {
            var loan = _loanRepository.GetLoanById(id);

            return loan;
        }

        public void UpdateLoan(LoanModel model)
        {
            var loan = _loanRepository.GetLoanById(model.Id);

            if (loan == null)
            {
                throw new Exception("Book not found");
            }

            _loanRepository.UpdateLoan(loan);
        }
    }
}
