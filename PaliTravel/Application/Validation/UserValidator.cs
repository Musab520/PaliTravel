using FluentValidation;
using PaliTravel.Domain.Model;

namespace PaliTravel.Application.Validation;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(user => user.PasswordHash)
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First name is required.");
    }
}