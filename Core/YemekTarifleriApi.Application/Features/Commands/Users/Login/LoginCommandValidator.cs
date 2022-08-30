using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
{
  public LoginCommandValidator()
  {
    RuleFor(x => x.Email)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .EmailAddress()
      .WithMessage("{PropertyName} not a valid email address");

    RuleFor(x => x.Password)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");
  }
}