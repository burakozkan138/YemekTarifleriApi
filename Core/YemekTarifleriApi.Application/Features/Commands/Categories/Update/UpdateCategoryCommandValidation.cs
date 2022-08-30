using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Update;

public class UpdateCategoryCommandValidation : AbstractValidator<UpdateCategoryCommandRequest>
{
  public UpdateCategoryCommandValidation()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");

    RuleFor(x => x.Name)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} must be at least {MinLength} characters.");

    RuleFor(x => x.Description)
      .MinimumLength(3)
      .WithMessage("The {PropertyName} must be at least {MinLength} characters.");
  }
}