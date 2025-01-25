using Domain.Model;
using FluentValidation;

namespace Application.Validation;

public class ConfirmationValidator : AbstractValidator<ConfirmationModel>
{
    public ConfirmationValidator()
    {
        RuleFor(confirmation => confirmation.ReservationId)
            .NotEmpty().WithMessage("ReservationId is required.");
        
        RuleFor(confirmation => confirmation.DealId)
            .NotEmpty().WithMessage("DealId is required.");
        
        RuleFor(confirmation => confirmation.ConfirmationNumber)
            .NotEmpty().WithMessage("ConfirmationNumber is required.");
    }
}