using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Persistence.Context;

namespace YemekTarifleriApi.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
  public CategoryRepository(YemekTarifleriDbContext context) : base(context)
  {
  }
}