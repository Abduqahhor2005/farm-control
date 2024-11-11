using FarmControl.Features.Entities;
using FluentValidation;

namespace FarmControl.Features.Validators;

public class FarmerValidator:AbstractValidator<Farmer>
{
    public FarmerValidator()
    {
        RuleFor(farmer => farmer.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .Length(4, 30).WithMessage("FullName must be between 4 and 30 characters.");

        RuleFor(farmer => farmer.Age)
            .NotEmpty().WithMessage("Age address is required.");
        
        RuleFor(farmer => farmer.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Length(4, 30).WithMessage("Email must be between 4 and 30 characters.");
        
        RuleFor(farmer => farmer.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required.")
            .Length(4, 30).WithMessage("PhoneNumber must be between 4 and 30 characters.");

        RuleFor(farmer => farmer.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(4, 30).WithMessage("Address must be between 4 and 30 characters.");
    }
}