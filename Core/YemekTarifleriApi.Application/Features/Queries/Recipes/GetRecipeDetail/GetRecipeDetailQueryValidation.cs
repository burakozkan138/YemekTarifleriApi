using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetRecipeDetail;

public class GetRecipeDetailQueryValidation : AbstractValidator<GetRecipeDetailQueryRequest>
{
  public GetRecipeDetailQueryValidation()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .WithMessage("The {PropertyName} field is required.");
  }
}