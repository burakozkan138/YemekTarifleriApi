using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Domain.Models;
using YemekTarifleriApi.Persistence.Context;

namespace YemekTarifleriApi.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
  readonly DbContext _context;
  readonly IConfiguration _configuration;

  public UserRepository(YemekTarifleriDbContext context, IConfiguration configuration) : base(context)
  {
    _context = context;
    _configuration = configuration;
  }

  public async Task UpdateRefreshToken(User user, string refreshToken)
  {
    user.RefreshToken = refreshToken;
    user.RefreshTokenExpires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshExpirationDateInMinute"]));

    Table.Update(user);
    await _context.SaveChangesAsync();
  }

  public async Task<bool> IsUniqueUser(string userName, string email)
  {
    return !await Table.AnyAsync(x => x.UserName == userName || x.Email == email);
  }
}