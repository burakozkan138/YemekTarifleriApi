using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
{
  public UpdateUserCommandValidator()
  {
    RuleFor(i => i.Email)
      .EmailAddress()
      .WithMessage("{PropertyName} not a valid email address");

    RuleFor(i => i.Name)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.Surname)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.UserName)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(i => i.Country)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");
  }
}