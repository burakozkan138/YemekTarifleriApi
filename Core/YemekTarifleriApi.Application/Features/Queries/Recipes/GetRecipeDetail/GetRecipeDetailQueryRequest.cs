using MediatR;
using Microsoft.AspNetCore.Mvc;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetRecipeDetail;

public class GetRecipeDetailQueryRequest : IRequest<Response<GetRecipeDetailQueryResponse>>
{
  [FromRoute] public string Id { get; set; }
}