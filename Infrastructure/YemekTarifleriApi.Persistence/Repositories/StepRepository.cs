using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Persistence.Context;

namespace YemekTarifleriApi.Persistence.Repositories;

public class StepRepository : GenericRepository<Step>, IStepRepository
{
  public StepRepository(YemekTarifleriDbContext context) : base(context)
  {
  }
}