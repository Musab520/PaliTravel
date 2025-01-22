using Domain.Model;
using FluentValidation;

namespace Application.Validation;

public class CityValidator : AbstractValidator<CityModel>
{
    public CityValidator()
    {
        RuleFor(city => city.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(city => city.Country)
            .NotEmpty().WithMessage("Country is required.");
    }
}