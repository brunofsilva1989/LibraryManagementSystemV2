using LibraryManagementSystem.Domain.Interfaces;

namespace LibraryManagementSystem.Application.Commands
{
    public class MarkLoanLateCommand
    {
        private readonly ILoanRepository _loanRepository;
        public MarkLoanLateCommand(ILoanRepository loanRepository) 
        {
            _loanRepository = loanRepository;
        }

        public void Execute() => _loanRepository.MarkLoanLate();
    }
}
