using Domain.Enum;
using Domain.SieveModel;
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
            .IsInEnum().WithMessage("Availability must be a valid value.");
        
        RuleFor(room => room.Price)
            .NotEmpty().WithMessage("Price is required.");
    }
}