using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Domain.Models;

public class Recipe : BaseEntity
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string? Image { get; set; }
  public Guid CategoryId { get; set; }
  public Guid CreatedById { get; set; }
  public virtual User CreatedBy { get; set; }
  public virtual Category Category { get; set; }
  public virtual ICollection<Ingredient> Ingredients { get; set; }
  public virtual ICollection<Step> Steps { get; set; }
}