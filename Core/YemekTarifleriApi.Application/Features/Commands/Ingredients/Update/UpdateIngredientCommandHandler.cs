using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Update;

public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommandRequest, Response<bool>>
{
  readonly IIngredientRepository _ingredientRepository;
  readonly IMapper _mapper;

  public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository, IMapper mapper)
  {
    _ingredientRepository = ingredientRepository;
    _mapper = mapper;
  }

  public async Task<Response<bool>> Handle(UpdateIngredientCommandRequest request, CancellationToken cancellationToken)
  {
    var ingredient = await _ingredientRepository.GetWhere(i => i.Id.ToString() == request.Id)
      .Include(x => x.Recipe)
      .FirstOrDefaultAsync(cancellationToken);

    if (ingredient == null)
      throw new Exception("Ingredient not found");

    if (ingredient.Recipe.CreatedById != request.UserId)
      throw new Exception("You are not allowed to update this ingredient");

    _mapper.Map(request, ingredient);
    return new Response<bool>(await _ingredientRepository.Update(ingredient) > 0);
  }
}