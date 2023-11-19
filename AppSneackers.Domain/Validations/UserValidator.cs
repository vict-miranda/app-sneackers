using AppSneackers.Domain.Entities;
using FluentValidation;

namespace AppSneackers.Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull().WithMessage("FirstName can not be null")
                .NotEmpty().WithMessage("FirstName can not be empty")
                .MaximumLength(50).WithMessage("FirstName can not exceed 50 characters");

            RuleFor(e => e.LastName)
                .NotNull().WithMessage("LastName can not be null")
                .NotEmpty().WithMessage("LastName can not be empty")
                .MaximumLength(50).WithMessage("LastName can not exceed 50 characters");

            RuleFor(e => e.Email)
                .NotNull().WithMessage("Email can not be null")
                .NotEmpty().WithMessage("Email can not be empty")
                .EmailAddress().WithMessage("A valid email is required")
                .MaximumLength(100).WithMessage("Email can not exceed 100 characters");

            RuleFor(e => e.Password)
                .NotNull().WithMessage("Password can not be null")
                .NotEmpty().WithMessage("Password can not be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(250).WithMessage("Password can not exceed 250 characters")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
