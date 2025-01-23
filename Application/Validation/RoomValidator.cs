using Domain.Model;
using FluentValidation;

namespace Application.Validation;

public class RoomValidator : AbstractValidator<RoomModel>
{
    public RoomValidator()
    {
        RuleFor(room => room.HotelId)
            .NotEmpty().WithMessage("HotelId is required.");
        
        RuleFor(room => room.RoomNumber)
            .NotEmpty().WithMessage("Room Number is required.");
        
        RuleFor(room => room.Availability)
            .NotEmpty().WithMessage("Availability is required.");
        
        RuleFor(room => room.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}