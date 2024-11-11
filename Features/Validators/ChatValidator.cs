using FarmControl.Features.Entities;
using FluentValidation;
namespace FarmControl.Features.Validators;

public class ChatValidator:AbstractValidator<Chat>
{
    public ChatValidator()
    {
        RuleFor(chat => chat.Comment)
            .NotEmpty().WithMessage("Comment is required.")
            .Length(4, 30).WithMessage("Comment must be between 4 and 30 characters.");

        RuleFor(chat => chat.TalkTime)
            .NotEmpty().WithMessage("TalkTime address is required.");

        RuleFor(chat => chat.FarmerId)
            .NotEmpty().WithMessage("FarmerId is required.");

        RuleFor(chat => chat.CustomerId)
            .NotEmpty().WithMessage("CustomerId password is required.");
    }
}