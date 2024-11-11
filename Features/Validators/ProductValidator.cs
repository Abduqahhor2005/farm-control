using FarmControl.Features.Entities;
using FluentValidation;

namespace FarmControl.Features.Validators;

public class ProductValidator:AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(4, 30).WithMessage("Name must be between 4 and 30 characters.");
        
        RuleFor(product => product.Price)
            .NotEmpty().WithMessage("Price address is required.");
        
        RuleFor(product => product.QuantityAvailable)
            .NotEmpty().WithMessage("QuantityAvailable address is required.");
        
        RuleFor(product => product.FarmerId)
            .NotEmpty().WithMessage("FarmerId is required.");
    }
}