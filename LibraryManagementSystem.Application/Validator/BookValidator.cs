using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryManagementSystem.Application.DTOs;

namespace LibraryManagementSystem.Application.Validator
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(50).WithMessage("Author cannot exceed 50 characters");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN is required")
                .Matches(@"^\d{13}$").WithMessage("ISBN must be exactly 13 digits");

            RuleFor(x => x.YearPublication)
                .InclusiveBetween(1500, 2025).WithMessage("Year must be between 1500 and 2025");
        }
    }
}
