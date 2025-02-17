using FluentValidation;
using LibraryManagementSystem.Application.DTOs;

namespace LibraryManagementSystem.Application.Validator
{
    public class UsersValidator : AbstractValidator<UsersDto>
    {
        public UsersValidator()
        {
            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF is required")
                .Matches(@"^\d{11}$").WithMessage("CPF must be exactly 11 digits");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MaximumLength(8).WithMessage("Password cannot exceed 8 characters");
            
        }
    }
}
