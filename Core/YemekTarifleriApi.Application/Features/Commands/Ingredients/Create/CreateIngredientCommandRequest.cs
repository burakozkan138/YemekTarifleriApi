using System.Text.Json.Serialization;
using MediatR;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Enums;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Create;

public class CreateIngredientCommandRequest : IRequest<Response<Guid>>
{
  public string RecipeId { get; set; }
  public string Name { get; set; }
  public float Quantity { get; set; }
  public RecipeUnits Unit { get; set; }
  [JsonIgnore] public Guid UserId { get; set; }
}