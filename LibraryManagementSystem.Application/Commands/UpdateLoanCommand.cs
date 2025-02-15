using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class UpdateLoanCommand
    {
        private readonly ILoanRepository _loanRepository;
        public UpdateLoanCommand(ILoanRepository loanRepository) 
        {
            _loanRepository = loanRepository;
        }

        public void Execute(LoanModel loanModel) => _loanRepository.UpdateLoan(loanModel);
    }
}
