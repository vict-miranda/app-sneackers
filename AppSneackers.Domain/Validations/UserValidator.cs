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
                .NotEmpty().WithMessage("FirstName can not be null")
                .MaximumLength(50).WithMessage("FirstName can not exceed 50 characters");

            RuleFor(e => e.LastName)
                .NotNull().WithMessage("LastName can not be null")
                .NotEmpty().WithMessage("LastName can not be null")
                .MaximumLength(50).WithMessage("LastName can not exceed 50 characters");

            RuleFor(e => e.Email)
                .NotNull().WithMessage("Email can not be null")
                .NotEmpty().WithMessage("Email can not be null")
                .MaximumLength(100).WithMessage("Email can not exceed 100 characters");

            RuleFor(e => e.Password)
                .NotNull().WithMessage("Password can not be null")
                .NotEmpty().WithMessage("Password can not be null")
                .MaximumLength(20).WithMessage("Password can not exceed 20 characters");
        }
    }
}
