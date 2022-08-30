using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Persistence.Context;

namespace YemekTarifleriApi.Persistence.Repositories;

public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
{
  public RecipeRepository(YemekTarifleriDbContext context) : base(context)
  {
  }
}