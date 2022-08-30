using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Categories.Delete;

public class DeleteCategoryCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
}