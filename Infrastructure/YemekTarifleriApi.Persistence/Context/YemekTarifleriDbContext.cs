using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Domain.Models.Common;
using YemekTarifleriApi.Persistence.Config;

namespace YemekTarifleriApi.Persistence.Context;

public class YemekTarifleriDbContext : DbContext
{
  protected YemekTarifleriDbContext()
  {
  }

  public YemekTarifleriDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Category> Categories { get; set; }
  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
  public DbSet<Step> Steps { get; set; }
  public DbSet<User> Users { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
      optionsBuilder.UseNpgsql(DatabaseConfiguration.GetConnectionString());

    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
    CancellationToken cancellationToken = new CancellationToken())
  {
    foreach (var data in ChangeTracker.Entries<BaseEntity>())
    {
      _ = data.State switch
      {
        EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
        EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
        _ => DateTime.UtcNow
      };
    }

    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
  }
}