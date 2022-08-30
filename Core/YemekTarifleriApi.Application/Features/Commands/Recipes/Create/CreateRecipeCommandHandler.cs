using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Create;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommandRequest, Response<Guid>>
{
  readonly ICategoryRepository _categoryRepository;
  readonly IUserRepository _userRepository;
  readonly IRecipeRepository _recipeRepository;
  readonly IMapper _mapper;

  public CreateRecipeCommandHandler(ICategoryRepository categoryRepository, IUserRepository userRepository, IRecipeRepository recipeRepository, IMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _userRepository = userRepository;
    _recipeRepository = recipeRepository;
    _mapper = mapper;
  }

  public async Task<Response<Guid>> Handle(CreateRecipeCommandRequest request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetByIdAsync(request.CreatedById);
    if (user == null)
      throw new Exception("User not found");

    var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
    if (category == null)
      throw new Exception("Category not found");

    var recipe = _mapper.Map<Recipe>(request);
    await _recipeRepository.AddAsync(recipe);

    return new Response<Guid>(recipe.Id);
  }
}