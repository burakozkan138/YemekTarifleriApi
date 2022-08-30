using System.Text.Json.Serialization;
using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Create;

public class CreateStepCommandRequest : IRequest<Response<Guid>>
{
  public string RecipeId { get; set; }
  public int Number { get; set; }
  public string Description { get; set; }
  [JsonIgnore] public Guid UserId { get; set; }
}