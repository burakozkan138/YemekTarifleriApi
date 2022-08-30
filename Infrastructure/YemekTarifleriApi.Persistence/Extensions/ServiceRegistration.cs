using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Persistence.Config;
using YemekTarifleriApi.Persistence.Context;
using YemekTarifleriApi.Persistence.Repositories;

namespace YemekTarifleriApi.Persistence.Extensions;

public static class ServiceRegistration
{
  public static void AddPersistenceServices(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddDbContext<YemekTarifleriDbContext>(options => options.UseNpgsql(DatabaseConfiguration.GetConnectionString()));
    //SeedData.SeedAsync().GetAwaiter().GetResult();
    serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
    serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();
    serviceCollection.AddScoped<IUserRepository, UserRepository>();
    serviceCollection.AddScoped<IStepRepository, StepRepository>();
    serviceCollection.AddScoped<IIngredientRepository, IngredientRepository>();
  }
}