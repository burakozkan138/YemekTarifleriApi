using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Update;

public class UpdateIngredientCommandValidation : AbstractValidator<UpdateIngredientCommandRequest>
{
  public UpdateIngredientCommandValidation()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");

    RuleFor(x => x.Name)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.Quantity)
      .GreaterThanOrEqualTo(1)
      .WithMessage("The {PropertyName} field must be greater than or equal to {ComparisonValue}.");
  }
}