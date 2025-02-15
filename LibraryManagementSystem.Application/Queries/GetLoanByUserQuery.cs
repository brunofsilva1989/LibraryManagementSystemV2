using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Queries
{
    public class GetLoanByUserQuery
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoanByUserQuery(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public LoanModel Execute(int userId) => _loanRepository.GetLoanByUser(userId);
    }
}
