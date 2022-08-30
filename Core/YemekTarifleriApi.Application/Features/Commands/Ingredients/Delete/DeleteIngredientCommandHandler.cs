using MediatR;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Delete;

public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommandRequest, Response<bool>>
{
  readonly IIngredientRepository _ingredientRepository;

  public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository)
  {
    _ingredientRepository = ingredientRepository;
  }

  public async Task<Response<bool>> Handle(DeleteIngredientCommandRequest request, CancellationToken cancellationToken)
  {
    var ingredient = await _ingredientRepository.GetWhere(i => i.Id.ToString() == request.Id)
      .Include(x => x.Recipe)
      .FirstOrDefaultAsync(cancellationToken);

    if (ingredient == null)
      throw new Exception("Ingredient not found");
    if (ingredient.Recipe.CreatedById != request.UserId)
      throw new Exception("You are not allowed to delete this ingredient");

    return new Response<bool>(await _ingredientRepository.Remove(ingredient) > 0);
  }
}