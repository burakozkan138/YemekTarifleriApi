using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Delete;

public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommandRequest, Response<bool>>
{
  readonly IRecipeRepository _recipeRepository;

  public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository)
  {
    _recipeRepository = recipeRepository;
  }

  public async Task<Response<bool>> Handle(DeleteRecipeCommandRequest request, CancellationToken cancellationToken)
  {
    var recipe = await _recipeRepository.GetByIdAsync(request.Id);
    if (recipe == null)
      throw new Exception("Recipe not found");

    if (recipe.CreatedById != request.UserId)
      throw new Exception("User is not authorized to delete this recipe");

    return new Response<bool>(await _recipeRepository.Remove(recipe) > 0);
  }
}