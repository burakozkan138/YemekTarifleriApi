using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Persistence.Context;

namespace YemekTarifleriApi.Persistence.Repositories;

public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
{
  public IngredientRepository(YemekTarifleriDbContext context) : base(context)
  {
  }
}