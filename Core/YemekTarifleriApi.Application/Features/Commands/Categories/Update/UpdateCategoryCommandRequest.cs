using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Update;

public class UpdateCategoryCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
}