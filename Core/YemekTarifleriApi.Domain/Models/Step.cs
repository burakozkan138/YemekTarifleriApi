using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Domain.Models;

public class Step : BaseEntity
{
  public Guid RecipeId { get; set; }
  public int Number { get; set; }
  public string Description { get; set; }
  public virtual Recipe Recipe { get; set; }
}