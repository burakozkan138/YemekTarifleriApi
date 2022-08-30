namespace YemekTarifleriApi.Application.Features.Queries.Recipes.GetAllRecipes;

public class GetAllRecipesQueryResponse
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Image { get; set; }
}