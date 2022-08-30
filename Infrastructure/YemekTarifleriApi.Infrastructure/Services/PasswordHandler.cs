using YemekTarifleriApi.Application.Services;

namespace YemekTarifleriApi.Infrastructure.Services;

public class PasswordHandler : IPasswordHandler
{
  public string HashPassword(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password);
  }

  public bool VerifyHashedPassword(string password, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
  }
}