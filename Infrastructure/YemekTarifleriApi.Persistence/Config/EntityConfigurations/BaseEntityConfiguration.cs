using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Persistence.Config.EntityConfigurations;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
  public virtual void Configure(EntityTypeBuilder<T> builder)
  {
    builder.HasKey(i => i.Id);
    builder.Property(i => i.Id).ValueGeneratedOnAdd();
    builder.Property(i => i.CreatedDate).ValueGeneratedOnAdd();
    builder.Property(i => i.UpdatedDate).ValueGeneratedOnUpdate();
  }
}