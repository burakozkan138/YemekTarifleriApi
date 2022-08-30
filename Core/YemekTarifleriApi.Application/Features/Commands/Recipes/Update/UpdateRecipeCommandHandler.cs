using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Update;

public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommandRequest, Response<bool>>
{
  readonly IRecipeRepository _recipeRepository;
  readonly ICategoryRepository _categoryRepository;
  readonly IMapper _mapper;

  public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, ICategoryRepository categoryRepository, IMapper mapper)
  {
    _recipeRepository = recipeRepository;
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }

  public async Task<Response<bool>> Handle(UpdateRecipeCommandRequest request, CancellationToken cancellationToken)
  {
    var recipe = await _recipeRepository.GetByIdAsync(request.Id);
    if (recipe is null)
      throw new Exception("Recipe not found");
    if (recipe.CreatedById != request.UserId)
      throw new Exception("You are not authorized to update this recipe");

    if (request.CategoryId != null)
    {
      var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
      if (category is null)
        throw new Exception("Category not found");
    }

    _mapper.Map(request, recipe);

    return new Response<bool>(await _recipeRepository.Update(recipe) > 0);
  }
}