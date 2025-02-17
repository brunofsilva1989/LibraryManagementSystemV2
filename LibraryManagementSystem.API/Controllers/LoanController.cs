using LibraryManagementSystem.Application.Commands;
using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Queries;
using LibraryManagementSystem.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using static LibraryManagementSystem.Domain.Enum.LoanEnums;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanController : Controller
    {
        private readonly DeleteLoanCommand _deleteLoanCommand;        
        private readonly UpdateLoanCommand _updateLoanCommand;
        private readonly CreateLoanCommand _createLoanCommand;
        private readonly MarkLoanLateCommand _markLoanLateCommand;
        private readonly RenewLoanCommand _renewLoanCommand;
        private readonly ReturnLoanCommand _returnLoanCommand;
        private readonly GetLoanByUserQuery _getLoanByUserQuery; 


        public LoanController(GetLoanByUserQuery getLoanByUserQuery,UpdateLoanCommand updateLoanCommand, CreateLoanCommand createLoanCommand, MarkLoanLateCommand markLoanLateCommand, RenewLoanCommand renewLoanCommand, ReturnLoanCommand returnLoanCommand)
        {            
            _updateLoanCommand = updateLoanCommand;
            _createLoanCommand = createLoanCommand;
            _markLoanLateCommand = markLoanLateCommand;
            _renewLoanCommand = renewLoanCommand;
            _returnLoanCommand = returnLoanCommand;
            _getLoanByUserQuery = getLoanByUserQuery;
        }


        /// <summary>
        /// Método para criar um empréstimo.
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-loan")]
        public IActionResult CreateLoan([FromBody] int userId, int bookId)
        {
            if (userId <= 0 || bookId <= 0)
            {
                return BadRequest("Invalid user or book Id");
            }

            _createLoanCommand.Execute(userId, bookId);
            
            return Ok("Loan created successfully!");
        }

        /// <summary>
        /// Método para trazer emprestimos por usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-loan-by-user/{id}")]
        public IActionResult GetLoanByUser(int userId)
        {
            var loan = _getLoanByUserQuery.Execute(userId);

            if (loan == null)
            {
                return NotFound("No Loan found for this user");
            }

            return Ok(loan);
        }

        /// <summary>
        /// Método para marcar um empréstimo como atrasado.
        /// </summary>
        /// <returns></returns>
        [HttpPost("return-loan/{loanId}")]
        public IActionResult ReturnLoan([FromBody] LoanDto loan)
        {
            if (loan.Id == null)
            {
                return NotFound("Loan not found!");
            }

            _returnLoanCommand.Execute(loan.Id);
            return Ok("Loan returned successfully!");
        }

        /// <summary>
        /// Método para renovar um empréstimo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("renew-loan/{loanId}")]
        public IActionResult RenewLoan([FromBody] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid loan Id");
            }

            _renewLoanCommand.Execute(id);
            return Ok("Loan renewed successfully!");
        }

        [HttpPost("update-loan")]
        public IActionResult UpdateLoan([FromBody] LoanDto loanDto)
        {
            var loanModel = new LoanModel
            {
                Id = loanDto.Id,
                IdUser = loanDto.IdUser,
                IdBook = loanDto.IdBook,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
                Status = (LoanStatus)loanDto.Status
            };

            if (loanModel == null)
            {
                return NotFound("Loan not found!");
            }

            _updateLoanCommand.Execute(loanModel);

            if (loanDto != null)
            {
                return Ok("Loan updated successfully!");
            }

            return Ok(loanDto);
        }

        /// <summary>
        /// Método para marcar um empréstimo como atrasado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("mark-late")]
        public IActionResult MarkLoanLate()
        {          
            _markLoanLateCommand.Execute();
            return Ok("Loan marked as late successfully!");
        }

        /// <summary>
        /// Método para deletar um empréstimo.
        /// </summary>
        /// <param name="loanId"></param>
        /// <returns></returns>
        [HttpDelete("delete-loan/{loanId}")]
        public IActionResult DeleteLoan(int loanId)
        {
            if (loanId == null)
            {
                throw new Exception("Loan  not found");
            }

            _deleteLoanCommand.Execute(loanId);
            return Ok("Loan deleted successfully!");
        }

    }
}
