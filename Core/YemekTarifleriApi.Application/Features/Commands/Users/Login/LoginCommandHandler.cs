using MediatR;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Services;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Response<Token>>
{
  readonly IUserRepository _userRepository;
  readonly IPasswordHandler _passwordHandler;
  readonly ITokenHandler _tokenHandler;

  public LoginCommandHandler(IUserRepository userRepository, IPasswordHandler passwordHandler, ITokenHandler tokenHandler)
  {
    _userRepository = userRepository;
    _passwordHandler = passwordHandler;
    _tokenHandler = tokenHandler;
  }

  public async Task<Response<Token>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
  {
    var user = await _userRepository.GetSingleAsync(u => u.Email == request.Email);
    if (user == null)
      throw new Exception("User not found");

    if (!_passwordHandler.VerifyHashedPassword(request.Password, user.Password))
      throw new Exception("Invalid password");

    var token = _tokenHandler.CreateAccessToken(user);
    await _userRepository.UpdateRefreshToken(user, token.RefreshToken);

    return new Response<Token>(token);
  }
}