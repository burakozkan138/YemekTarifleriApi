using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Filters;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetAllRecipes;

public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQueryRequest, PagedResponse<List<GetAllRecipesQueryResponse>>>
{
  readonly IRecipeRepository _recipeRepository;
  readonly IMapper _mapper;

  public GetAllRecipesQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
  {
    _recipeRepository = recipeRepository;
    _mapper = mapper;
  }

  public async Task<PagedResponse<List<GetAllRecipesQueryResponse>>> Handle(GetAllRecipesQueryRequest request, CancellationToken cancellationToken)
  {
    var validFilter = new PaginationFilter(request.PageNumber, request.PageSize);
    var recipes = _recipeRepository.GetAll()
      .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
      .Take(validFilter.PageSize)
      .ToList();
    var totalRecords = await _recipeRepository.CountAsync();
    var data = _mapper.Map<List<GetAllRecipesQueryResponse>>(recipes);

    return new PagedResponse<List<GetAllRecipesQueryResponse>>(data, validFilter.PageNumber, validFilter.PageSize, Convert.ToInt32(Math.Ceiling(totalRecords / (double)validFilter.PageSize)), totalRecords);
  }
}