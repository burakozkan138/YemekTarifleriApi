using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Create;

public class CreateIngredientCommandValidation : AbstractValidator<CreateIngredientCommandRequest>
{
  public CreateIngredientCommandValidation()
  {
    RuleFor(x => x.Name)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");
    RuleFor(x => x.RecipeId)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");

    RuleFor(x => x.Unit)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");

    RuleFor(x => x.Quantity)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .GreaterThanOrEqualTo(1)
      .WithMessage("The {PropertyName} field must be greater than or equal to {ComparisonValue}.");
  }
}