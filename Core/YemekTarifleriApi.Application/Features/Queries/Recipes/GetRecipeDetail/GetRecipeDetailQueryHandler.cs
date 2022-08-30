using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetRecipeDetail;

public class GetRecipeDetailQueryHandler : IRequestHandler<GetRecipeDetailQueryRequest, Response<GetRecipeDetailQueryResponse>>
{
  readonly IRecipeRepository _recipeRepository;
  readonly IMapper _mapper;

  public GetRecipeDetailQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
  {
    _recipeRepository = recipeRepository;
    _mapper = mapper;
  }

  public async Task<Response<GetRecipeDetailQueryResponse>> Handle(GetRecipeDetailQueryRequest request, CancellationToken cancellationToken)
  {
    var recipe = await _recipeRepository.GetWhere(x => x.Id.ToString() == request.Id)
      .Include(x => x.Category)
      .Include(x => x.CreatedBy)
      .Include(x => x.Ingredients)
      .Include(x => x.Steps)
      .FirstOrDefaultAsync(cancellationToken: cancellationToken);

    if (recipe is null)
      throw new Exception("Recipe not found");

    return new Response<GetRecipeDetailQueryResponse>(_mapper.Map<GetRecipeDetailQueryResponse>(recipe));
  }
}