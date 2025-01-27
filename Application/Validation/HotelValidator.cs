using Domain.SieveModel;
using FluentValidation;

namespace Application.Validation;

public class HotelValidator : AbstractValidator<HotelModel>
{
    public HotelValidator()
    {
        RuleFor(hotel => hotel.Name)
            .NotEmpty().WithMessage("Name is required.");
        
        RuleFor(hotel => hotel.StarRating)
            .NotEmpty().WithMessage("Rating is required.");
        
        RuleFor(hotel => hotel.CityId)
            .NotEmpty().WithMessage("City is required.");
    }
}