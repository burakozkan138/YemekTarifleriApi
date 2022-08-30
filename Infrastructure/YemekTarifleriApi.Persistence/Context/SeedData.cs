using Bogus;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Domain.Enums;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Persistence.Config;

namespace YemekTarifleriApi.Persistence.Context;

public static class SeedData
{
  public static async Task SeedAsync()
  {
    var dbContextBuilder = new DbContextOptionsBuilder();
    dbContextBuilder.UseNpgsql(DatabaseConfiguration.GetConnectionString());
    var context = new YemekTarifleriDbContext(dbContextBuilder.Options);

    if (context.Users.Any() && context.Recipes.Any() && context.Categories.Any()) return;

    var users = GetUsers();
    var userIds = users.Select(i => i.Id).ToList();
    await context.Users.AddRangeAsync(users);

    var categories = GetCategories();
    var categoryIds = categories.Select(i => i.Id).ToList();
    await context.Categories.AddRangeAsync(categories);

    var guids = Enumerable.Range(0, 150).Select(_ => Guid.NewGuid()).ToList();
    await context.Recipes.AddRangeAsync(GetRecipes(guids, userIds, categoryIds));
    await context.Ingredients.AddRangeAsync(GetRecipeIngredients(guids));
    await context.Steps.AddRangeAsync(GetRecipeSteps(guids));

    await context.SaveChangesAsync();
  }

  static List<User> GetUsers()
  {
    return new Faker<User>("tr")
      .RuleFor(i => i.Id, _ => Guid.NewGuid())
      .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
      .RuleFor(i => i.Name, i => i.Person.FirstName)
      .RuleFor(i => i.Surname, i => i.Person.LastName)
      .RuleFor(i => i.Email, i => i.Internet.Email())
      .RuleFor(i => i.UserName, i => i.Internet.UserName())
      .RuleFor(i => i.Password, _ => "$2a$11$W43nsI98wsVRZo9rh9i/Junkdal81TV6R5TSOeYIxNhsQy1U.McmS") //pass= password
      .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
      .Generate(100);
  }

  static List<Category> GetCategories()
  {
    return new Faker<Category>("tr")
      .RuleFor(i => i.Id, _ => Guid.NewGuid())
      .RuleFor(i => i.Name, i => i.Lorem.Sentence(2, 2))
      .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
      .Generate(10);
  }

  static List<Recipe> GetRecipes(List<Guid> guids, IEnumerable<Guid> userIds, IEnumerable<Guid> categoryIds)
  {
    int counter = 0;
    return new Faker<Recipe>("tr")
      .RuleFor(i => i.Id, _ => guids[counter++])
      .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
      .RuleFor(i => i.Name, i => i.Lorem.Sentence(2, 2))
      .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
      .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
      .RuleFor(i => i.CategoryId, i => i.PickRandom(categoryIds))
      .RuleFor(i => i.Image, _ => "images/default.png")
      .Generate(150);
  }

  static List<Ingredient> GetRecipeIngredients(List<Guid> guids)
  {
    return new Faker<Ingredient>("tr")
      .RuleFor(i => i.Id, _ => Guid.NewGuid())
      .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
      .RuleFor(i => i.Name, i => i.Lorem.Paragraph(2))
      .RuleFor(i => i.Quantity, i => i.Random.Float())
      .RuleFor(i => i.Unit, i => i.PickRandom<RecipeUnits>())
      .RuleFor(i => i.RecipeId, i => i.PickRandom(guids))
      .Generate(500);
  }

  static List<Step> GetRecipeSteps(List<Guid> guids)
  {
    return new Faker<Step>("tr")
      .RuleFor(i => i.Id, _ => Guid.NewGuid())
      .RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
      .RuleFor(i => i.Description, i => i.Lorem.Paragraph(2))
      .RuleFor(i => i.RecipeId, i => i.PickRandom(guids))
      .RuleFor(i => i.Number, i => i.Random.Int(1, 10))
      .Generate(500);
  }
}