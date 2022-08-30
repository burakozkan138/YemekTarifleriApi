using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Persistence.Config.EntityConfigurations;

public class RecipeEntityConfiguration : BaseEntityConfiguration<Recipe>
{
  public override void Configure(EntityTypeBuilder<Recipe> builder)
  {
    base.Configure(builder);
    builder.HasOne(i => i.CreatedBy).WithMany(i => i.Recipes).HasForeignKey(i => i.CreatedById);
    builder.HasOne(i => i.Category).WithMany(i => i.Recipes).HasForeignKey(i => i.CategoryId);
    builder.HasMany(i => i.Ingredients).WithOne(i => i.Recipe).HasForeignKey(i => i.RecipeId);
    builder.HasMany(i => i.Steps).WithOne(i => i.Recipe).HasForeignKey(i => i.RecipeId);
  }
}