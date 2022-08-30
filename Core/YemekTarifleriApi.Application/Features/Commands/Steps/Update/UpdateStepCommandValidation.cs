using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Update;

public class UpdateStepCommandValidation : AbstractValidator<UpdateStepCommandRequest>
{
  public UpdateStepCommandValidation()
  {
    RuleFor(x => x.Description)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.Number)
      .GreaterThanOrEqualTo(1)
      .WithMessage("The {PropertyName} field must be greater than or equal to {ComparisonValue}.");
  }
}