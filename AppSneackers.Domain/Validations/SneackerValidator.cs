﻿using AppSneackers.Domain.Aggregates;
using FluentValidation;

namespace AppSneackers.Domain.Validations
{
    public class SneackerValidator : AbstractValidator<Sneacker>
    {
        public SneackerValidator()
        {
            RuleFor(e => e.Name)
               .NotNull().WithMessage("Name can not be null")
               .NotEmpty().WithMessage("Name can not be empty")
               .MaximumLength(100).WithMessage("Name can not exceed 100 characters");

            RuleFor(e => e.Brand)
               .NotNull().WithMessage("Brand can not be null")
               .NotEmpty().WithMessage("Brand can not be empty")
               .MaximumLength(50).WithMessage("Brand can not exceed 50 characters");

            RuleFor(e => e.Price)
               .NotNull().WithMessage("Price can not be null")
               .NotEmpty().WithMessage("Price can not be empty");

            RuleFor(e => e.Size)
               .NotNull().WithMessage("Size can not be null")
               .NotEmpty().WithMessage("Size can not be empty");

            RuleFor(e => e.Year)
               .NotNull().WithMessage("Year can not be null")
               .NotEmpty().WithMessage("Year can not be empty");

            RuleFor(e => e.Rate)
               .NotNull().WithMessage("Rate can not be null")
               .NotEmpty().WithMessage("Rate can not be empty")
               .GreaterThan(0)
               .LessThan(6);
        }
    }
}
