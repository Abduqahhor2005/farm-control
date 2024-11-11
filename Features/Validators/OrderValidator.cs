using FarmControl.Features.Entities;
using FluentValidation;

namespace FarmControl.Features.Validators;

public class OrderValidator:AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.Quantity)
            .NotEmpty().WithMessage("Quantity address is required.");
        
        RuleFor(order => order.OrderDate)
            .NotEmpty().WithMessage("OrderDate address is required.");
        
        RuleFor(order => order.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");
        
        RuleFor(order => order.CustomerId)
            .NotEmpty().WithMessage("CustomerId address is required.");
    }
}