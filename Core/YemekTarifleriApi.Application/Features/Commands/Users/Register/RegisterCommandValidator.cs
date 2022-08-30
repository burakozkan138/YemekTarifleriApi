using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
  public RegisterCommandValidator()
  {
    RuleFor(i => i.Email)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .EmailAddress()
      .WithMessage("{PropertyName} not a valid email address");

    RuleFor(i => i.Name)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.Surname)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.UserName)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.Password)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.ConfirmPassword)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");
  }
}