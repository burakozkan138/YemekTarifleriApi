using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Response<bool>>
{
  readonly ICategoryRepository _categoryRepository;

  public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<Response<bool>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
  {
    var category = await _categoryRepository.GetByIdAsync(request.Id);
    if (category is null)
      throw new Exception("Category not found");

    return new Response<bool>(await _categoryRepository.Remove(category) > 0);
  }
}