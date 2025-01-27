using Domain.SieveModel;
using FluentValidation;

namespace Application.Validation;

public class DealValidator : AbstractValidator<DealModel>
{
    public DealValidator()
    {
        RuleFor(deal => deal.RoomId)
            .NotEmpty().WithMessage("RoomId is required.");
        
        RuleFor(deal => deal.HotelId)
            .NotEmpty().WithMessage("HotelId is required.");
        
        RuleFor(deal => deal.FromDate)
            .NotEmpty().WithMessage("FromDate is required.");
        
        RuleFor(deal => deal.ToDate)
            .NotEmpty().WithMessage("ToDate is required.");
        
        RuleFor(deal => deal.Discount)
            .NotEmpty().WithMessage("Discount is required.");
    }
}