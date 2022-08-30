using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Services;

public interface ITokenHandler
{
  public Token CreateAccessToken(User user);
  public string CreateRefreshToken();
}