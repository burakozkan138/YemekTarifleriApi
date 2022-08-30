using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Services;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Infrastructure.Services;

public class TokenHandler : ITokenHandler
{
  readonly IConfiguration _configuration;
  readonly IUserRepository _userRepository;

  public TokenHandler(IConfiguration configuration, IUserRepository userRepository)
  {
    _configuration = configuration;
    _userRepository = userRepository;
  }

  public Token CreateAccessToken(User user)
  {
    Token token = new Token();
    token.Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:AccessExpirationDateInMinute"]));

    JwtSecurityToken securityToken = new JwtSecurityToken(
      issuer: _configuration["Jwt:Issuer"],
      audience: _configuration["Jwt:Audience"],
      expires: token.Expires,
      notBefore: DateTime.UtcNow,
      signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"])), SecurityAlgorithms.HmacSha256),
      claims: new List<Claim>
      {
        new(ClaimTypes.Name, user.UserName),
        new(ClaimTypes.NameIdentifier, user.Id.ToString())
      }
    );

    token.AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
    token.RefreshToken = CreateRefreshToken();
    return token;
  }

  public string CreateRefreshToken()
  {
    var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    return _userRepository.Table.Any(u => u.RefreshToken == token) ? CreateRefreshToken() : token;
  }
}