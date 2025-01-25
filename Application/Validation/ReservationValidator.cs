using Domain.Model;
using FluentValidation;

namespace Application.Validation;

public class ReservationValidator : AbstractValidator<ReservationModel>
{
    public ReservationValidator()
    {
        RuleFor(reservation => reservation.RoomId)
            .NotEmpty().WithMessage("RoomId is required.");
        
        RuleFor(reservation => reservation.HotelId)
            .NotEmpty().WithMessage("HotelId is required.");
        
        RuleFor(reservation => reservation.CheckIn)
            .NotEmpty().WithMessage("CheckIn is required.");
        
        RuleFor(reservation => reservation.CheckOut)
            .NotEmpty().WithMessage("CheckOut is required.");
    }
}