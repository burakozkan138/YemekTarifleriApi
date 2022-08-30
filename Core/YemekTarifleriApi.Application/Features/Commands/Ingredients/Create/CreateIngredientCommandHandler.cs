using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Create;

public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommandRequest, Response<Guid>>
{
  readonly IRecipeRepository _recipeRepository;
  readonly IIngredientRepository _ingredientRepository;
  readonly IMapper _mapper;

  public CreateIngredientCommandHandler(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IMapper mapper)
  {
    _recipeRepository = recipeRepository;
    _ingredientRepository = ingredientRepository;
    _mapper = mapper;
  }

  public async Task<Response<Guid>> Handle(CreateIngredientCommandRequest request, CancellationToken cancellationToken)
  {
    var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);
    if (recipe == null)
      throw new Exception("Recipe not found");

    if (recipe.CreatedById != request.UserId)
      throw new UnauthorizedAccessException("You are not authorized to create ingredients for this recipe");

    var ingredient = _mapper.Map<Ingredient>(request);
    await _ingredientRepository.AddAsync(ingredient);

    return new Response<Guid>(ingredient.Id);
  }
}