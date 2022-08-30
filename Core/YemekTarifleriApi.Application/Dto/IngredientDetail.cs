using YemekTarifleriApi.Domain.Enums;

namespace YemekTarifleriApi.Application.Dto;

public class IngredientDetail
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public float Quantity { get; set; }
  public RecipeUnits Unit { get; set; }
}