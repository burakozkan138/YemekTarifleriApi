using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
  Task UpdateRefreshToken(User user, string refreshToken);
  Task<bool> IsUniqueUser(string userName, string email);
}