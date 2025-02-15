using LibraryManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class RenewLoanCommand
    {
        private readonly ILoanRepository _loanRepository;
        public RenewLoanCommand(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public void Execute(int loanId) => _loanRepository.RenewLoan(loanId);
    }
}
