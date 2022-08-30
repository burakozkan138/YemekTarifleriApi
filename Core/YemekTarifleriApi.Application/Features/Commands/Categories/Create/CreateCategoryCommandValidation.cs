using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Create;

public class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommandRequest>
{
  public CreateCategoryCommandValidation()
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
  }
}