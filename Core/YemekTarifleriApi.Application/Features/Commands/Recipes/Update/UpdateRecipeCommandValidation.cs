using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Update;

public class UpdateRecipeCommandValidation : AbstractValidator<UpdateRecipeCommandRequest>
{
  public UpdateRecipeCommandValidation()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");

    RuleFor(x => x.Name)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.Description)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} field cannot be empty and must be at least {MinLength} characters.");

    RuleFor(x => x.CategoryId)
      .NotEmpty()
      .WithMessage("The {PropertyName} field cannot be empty");
  }
}