using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Create;

public class CreateRecipeCommandValidation : AbstractValidator<CreateRecipeCommandRequest>
{
  public CreateRecipeCommandValidation()
  {
    RuleFor(x => x.Name)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.Description)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.CategoryId)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.")
      .NotEmpty()
      .WithMessage("The {PropertyName} field cannot be empty");
  }
}