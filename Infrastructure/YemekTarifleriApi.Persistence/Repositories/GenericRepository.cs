using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Domain.Models.Common;

namespace YemekTarifleriApi.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
  readonly DbContext _context;

  protected GenericRepository(DbContext context)
  {
    _context = context;
  }

  public DbSet<T> Table => _context.Set<T>();

  public async Task<int> CountAsync()
  {
    return await Table.CountAsync();
  }

  public IQueryable<T> GetAll(bool tracking = true)
  {
    var query = Table.AsQueryable();
    if (!tracking)
      query = query.AsNoTracking();

    return query;
  }

  public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
  {
    var query = Table.Where(method);
    if (!tracking)
      query = query.AsNoTracking();

    return query;
  }

  public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
  {
    var query = Table.AsQueryable();
    if (!tracking)
      query = query.AsNoTracking();

    return await query.FirstOrDefaultAsync(method);
  }

  public async Task<T> GetByIdAsync(string id, bool tracking = true)
  {
    try
    {
      return await GetByIdAsync(Guid.Parse(id), tracking);
    }
    catch (FormatException)
    {
      return null;
    }
  }

  public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
  {
    var query = Table.AsQueryable();
    if (!tracking)
      query = query.AsNoTracking();

    return await query.FirstOrDefaultAsync(data => data.Id == id);
  }

  public async Task<int> AddAsync(T model)
  {
    await Table.AddAsync(model);
    return await _context.SaveChangesAsync();
  }

  public async Task<int> AddRangeAsync(List<T> model)
  {
    await Table.AddRangeAsync(model);

    return await _context.SaveChangesAsync();
  }

  public async Task<int> Remove(T data)
  {
    Table.Remove(data);
    return await _context.SaveChangesAsync();
  }

  public async Task<int> RemoveRange(List<T> data)
  {
    Table.RemoveRange(data);
    return await _context.SaveChangesAsync();
  }

  public async Task<int> Update(T model)
  {
    Table.Update(model);
    return await _context.SaveChangesAsync();
  }
}