using MediatR;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Services;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.RefreshTokenLogin;

public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, Response<Token>>
{
  readonly IUserRepository _userRepository;
  readonly ITokenHandler _tokenHandler;

  public RefreshTokenLoginCommandHandler(IUserRepository userRepository, ITokenHandler tokenHandler)
  {
    _userRepository = userRepository;
    _tokenHandler = tokenHandler;
  }

  public async Task<Response<Token>> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetWhere(u => u.RefreshToken == request.RefreshToken).FirstOrDefaultAsync(cancellationToken);
    if (user == null || user.RefreshTokenExpires < DateTime.UtcNow)
      throw new Exception("User not found");

    var token = _tokenHandler.CreateAccessToken(user);
    await _userRepository.UpdateRefreshToken(user, token.RefreshToken);

    return new Response<Token>(token);
  }
}