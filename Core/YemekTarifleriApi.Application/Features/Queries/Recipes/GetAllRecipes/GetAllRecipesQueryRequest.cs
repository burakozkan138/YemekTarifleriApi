using MediatR;
using YemekTarifleriApi.Application.Filters;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetAllRecipes;

public class GetAllRecipesQueryRequest : PaginationFilter, IRequest<PagedResponse<List<GetAllRecipesQueryResponse>>>
{
}