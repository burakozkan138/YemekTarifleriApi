using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Create;

public class CreateCategoryCommandRequest : IRequest<Response<Guid>>
{
  public string Name { get; set; }
  public string Description { get; set; }
}