using LibraryManagementSystem.Application.DTOs;
using LibraryManagementSystem.Application.Services;
using LibraryManagementSystem.Domain.Enum;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanController : Controller
    {
        private readonly GetLoansUseCase _getLoansUseCase;

        public LoanController(GetLoansUseCase getLoansUseCase)
        {
            _getLoansUseCase = getLoansUseCase;
        }
        /// <summary>
        /// Método para buscar todos os empréstimos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllLoans()
        {
            var loan = _getLoansUseCase.GetAllLoans();

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);

        }

        /// <summary>
        /// Método para buscar um empréstimo com base num id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loan = _getLoansUseCase.GetLoanById(id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        /// <summary>
        /// Método para criar um novo empréstimo.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateLoan(LoanDto loanDto)
        {
            var loan = new LoanModel
            {
                IdUser = loanDto.IdUser,
                IdBook = loanDto.IdBook,
                Loans = loanDto.Loans,
                LoanDate = loanDto.LoanDate,
                ReturnDate = loanDto.ReturnDate,
                Status = (LoanEnums.LoanStatus)loanDto.Status,
            };

            _getLoansUseCase.CreateLoan(loan);

            return Ok(loan);
        }

        /// <summary>
        /// Método para atualizar um empréstimo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateLoan(int id)
        {
            var loan = _getLoansUseCase.GetLoanById(id);

            if (loan == null)
            {
                return NotFound();
            }

            _getLoansUseCase.UpdateLoan(loan);

            return Ok(loan);
        }

        /// <summary>
        /// Método para deletar um empréstimo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteLoan(int id)
        {
            var loan = _getLoansUseCase.GetLoanById(id);

            if (loan == null) 
            {
                return NotFound();
            }

            _getLoansUseCase.DeleteLoan(loan.Id);

            return Ok(id);
        }

    }
}
