using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
  DbSet<T> Table { get; }

  Task<int> CountAsync();
  IQueryable<T> GetAll(bool tracking = true);
  IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
  Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
  Task<T> GetByIdAsync(string id, bool tracking = true);
  Task<T> GetByIdAsync(Guid id, bool tracking = true);
  Task<int> AddAsync(T model);
  Task<int> AddRangeAsync(List<T> model);
  Task<int> Remove(T data);
  Task<int> RemoveRange(List<T> data);
  Task<int> Update(T model);
}