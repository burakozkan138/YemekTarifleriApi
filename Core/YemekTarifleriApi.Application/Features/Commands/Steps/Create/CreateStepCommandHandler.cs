using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Create;

public class CreateStepCommandHandler : IRequestHandler<CreateStepCommandRequest, Response<Guid>>
{
  readonly IRecipeRepository _recipeRepository;
  readonly IStepRepository _stepRepository;
  readonly IMapper _mapper;

  public CreateStepCommandHandler(IRecipeRepository recipeRepository, IStepRepository stepRepository, IMapper mapper)
  {
    _recipeRepository = recipeRepository;
    _stepRepository = stepRepository;
    _mapper = mapper;
  }

  public async Task<Response<Guid>> Handle(CreateStepCommandRequest request, CancellationToken cancellationToken)
  {
    var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

    if (recipe == null)
      throw new Exception("Recipe not found");

    if (recipe.CreatedById != request.UserId)
      throw new Exception("You are not allowed to create steps for this recipe");

    var step = _mapper.Map<Step>(request);
    await _stepRepository.AddAsync(step);

    return new Response<Guid>(step.Id);
  }
}