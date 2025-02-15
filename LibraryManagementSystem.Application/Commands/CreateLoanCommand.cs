using LibraryManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Commands
{
    public class CreateLoanCommand
    {
        private readonly ILoanRepository _loanRepository;

        public CreateLoanCommand(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public void Execute(int userId, int bookId) => _loanRepository.CreateLoan(userId, bookId);

    }
}
