using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Users.RefreshTokenLogin;

public class RefreshTokenLoginCommandValidator : AbstractValidator<RefreshTokenLoginCommandRequest>
{
  public RefreshTokenLoginCommandValidator()
  {
    RuleFor(x => x.RefreshToken)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");
  }
}