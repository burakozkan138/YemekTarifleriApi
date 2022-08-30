using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Delete;

public class DeleteCategoryCommandValidation : AbstractValidator<DeleteCategoryCommandRequest>
{
  public DeleteCategoryCommandValidation()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");
  }
}