using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Queries.Categories.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, Response<List<GetAllCategoriesQueryResponse>>>
{
  readonly ICategoryRepository _categoryRepository;
  readonly IMapper _mapper;

  public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }

  public async Task<Response<List<GetAllCategoriesQueryResponse>>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
  {
    return new Response<List<GetAllCategoriesQueryResponse>>(_mapper.Map<List<GetAllCategoriesQueryResponse>>(_categoryRepository.GetAll(false).ToList()));
  }
}