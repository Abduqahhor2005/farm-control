using FarmControl.Features.Entities;
using FluentValidation;

namespace FarmControl.Features.Validators;

public class CustomerValidator:AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .Length(4, 30).WithMessage("FullName must be between 4 and 30 characters.");

        RuleFor(customer => customer.Age)
            .NotEmpty().WithMessage("Age address is required.");
        
        RuleFor(customer => customer.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Length(4, 30).WithMessage("Email must be between 4 and 30 characters.");
        
        RuleFor(customer => customer.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required.")
            .Length(4, 30).WithMessage("PhoneNumber must be between 4 and 30 characters.");

        RuleFor(customer => customer.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(4, 30).WithMessage("Address must be between 4 and 30 characters.");
    }
}