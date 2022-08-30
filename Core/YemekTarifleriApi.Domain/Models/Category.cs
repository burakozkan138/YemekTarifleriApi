using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Domain.Models;

public class Category : BaseEntity
{
  public string Name { get; set; }
  public string Description { get; set; }
  public virtual ICollection<Recipe> Recipes { get; set; }
}