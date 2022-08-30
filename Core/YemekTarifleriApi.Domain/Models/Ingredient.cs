using YemekTarifleriApi.Domain.Enums;
using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Domain.Models;

public class Ingredient : BaseEntity
{
  public Guid RecipeId { get; set; }
  public string Name { get; set; }
  public float Quantity { get; set; }
  public RecipeUnits Unit { get; set; }
  public virtual Recipe Recipe { get; set; }
}