using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Queries.Categories.GetAllCategories;

public class GetAllCategoriesQueryRequest : IRequest<Response<List<GetAllCategoriesQueryResponse>>>
{
}