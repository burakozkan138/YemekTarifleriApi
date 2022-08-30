using System.Text.Json.Serialization;
using MediatR;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Enums;

namespace YemekTarifleriApi.Application.Features.Commands.Ingredients.Update;

public class UpdateIngredientCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public float Quantity { get; set; }
  public RecipeUnits Unit { get; set; }
  [JsonIgnore] public Guid UserId { get; set; }
}