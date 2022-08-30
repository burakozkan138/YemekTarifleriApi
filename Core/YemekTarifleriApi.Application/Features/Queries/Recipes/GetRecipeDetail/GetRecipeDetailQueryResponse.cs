using YemekTarifleriApi.Application.Dto;

namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetRecipeDetail;

public class GetRecipeDetailQueryResponse
{
  public Guid Id { get; set; }
  public string CategoryName { get; set; }
  public string CreatedByUserName { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Image { get; set; }
  public DateTime CreatedDate { get; set; }
  public List<IngredientDetail> Ingredients { get; set; }
  public List<StepDetail> Steps { get; set; }
}