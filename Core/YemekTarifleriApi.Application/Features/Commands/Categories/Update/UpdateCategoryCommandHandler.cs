using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Response<bool>>
{
  readonly ICategoryRepository _categoryRepository;
  readonly IMapper _mapper;

  public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }

  public async Task<Response<bool>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
  {
    var dbCategory = await _categoryRepository.GetByIdAsync(request.Id);
    if (dbCategory is null)
      throw new Exception("Category not found");

    _mapper.Map(request, dbCategory);
    return new Response<bool>(await _categoryRepository.Update(dbCategory) > 0);
  }
}