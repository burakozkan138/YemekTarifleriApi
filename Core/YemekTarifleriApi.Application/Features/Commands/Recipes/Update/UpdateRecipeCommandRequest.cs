using System.Text.Json.Serialization;
using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Update;

public class UpdateRecipeCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public Guid CategoryId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  [JsonIgnore] public Guid UserId { get; set; }
}