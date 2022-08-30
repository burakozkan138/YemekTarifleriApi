using System.Text.Json.Serialization;
using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Create;

public class CreateRecipeCommandRequest : IRequest<Response<Guid>>
{
  public string CategoryId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  [JsonIgnore] public Guid CreatedById { get; set; }
}