using FarmControl.Features.Entities;
using FluentValidation;

namespace FarmControl.Features.Validators;

public class FieldValidator:AbstractValidator<Field>
{
    public FieldValidator()
    {
        RuleFor(field => field.Location)
            .NotEmpty().WithMessage("Location is required.")
            .Length(4, 30).WithMessage("Location must be between 4 and 30 characters.");

        RuleFor(field => field.Area)
            .NotEmpty().WithMessage("Area address is required.");
        
        RuleFor(field => field.FarmerId)
            .NotEmpty().WithMessage("FarmerId address is required.");
    }
}