using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Response<Guid>>
{
  readonly ICategoryRepository _categoryRepository;
  readonly IMapper _mapper;

  public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }

  public async Task<Response<Guid>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
  {
    var category = _mapper.Map<Category>(request);
    await _categoryRepository.AddAsync(category);

    return new Response<Guid>(category.Id);
  }
}