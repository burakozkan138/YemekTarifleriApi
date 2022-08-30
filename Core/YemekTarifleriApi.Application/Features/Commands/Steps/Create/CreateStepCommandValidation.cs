using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Create;

public class CreateStepCommandValidation : AbstractValidator<CreateStepCommandRequest>
{
  public CreateStepCommandValidation()
  {
    RuleFor(x => x.Description)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.RecipeId)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");

    RuleFor(x => x.Number)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .GreaterThanOrEqualTo(1)
      .WithMessage("The {PropertyName} field must be greater than or equal to {ComparisonValue}.");
  }
}