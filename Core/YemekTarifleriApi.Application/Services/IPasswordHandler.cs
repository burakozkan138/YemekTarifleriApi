namespace YemekTarifleriApi.Application.Services;

public interface IPasswordHandler
{
  public string HashPassword(string password);
  public bool VerifyHashedPassword(string hashedPassword, string password);
}