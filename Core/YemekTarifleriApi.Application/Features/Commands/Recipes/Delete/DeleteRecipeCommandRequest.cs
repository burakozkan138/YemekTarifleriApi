using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Delete;

public class DeleteRecipeCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public Guid UserId { get; set; }

  public DeleteRecipeCommandRequest(string id, Guid userId)
  {
    Id = id;
    UserId = userId;
  }
}