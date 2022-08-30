using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Delete;

public class DeleteIngredientCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public Guid UserId { get; set; }

  public DeleteIngredientCommandRequest(string id, Guid userId)
  {
    Id = id;
    UserId = userId;
  }
}