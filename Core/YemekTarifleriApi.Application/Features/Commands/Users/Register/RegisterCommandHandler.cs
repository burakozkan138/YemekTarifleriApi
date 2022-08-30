using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Services;
using YemekTarifleriApi.Application.Wrappers;
using YemekTarifleriApi.Domain.Models;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Response<Token>>
{
  readonly IUserRepository _userRepository;
  readonly IPasswordHandler _passwordHandler;
  readonly ITokenHandler _tokenHandler;
  readonly IMapper _mapper;

  public RegisterCommandHandler(IUserRepository userRepository, IPasswordHandler passwordHandler, ITokenHandler tokenHandler, IMapper mapper)
  {
    _userRepository = userRepository;
    _passwordHandler = passwordHandler;
    _tokenHandler = tokenHandler;
    _mapper = mapper;
  }

  public async Task<Response<Token>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
  {
    if (!await _userRepository.IsUniqueUser(request.UserName, request.Email))
      throw new Exception("User already exists");

    var user = _mapper.Map<User>(request);
    user.Password = _passwordHandler.HashPassword(user.Password);
    var token = _tokenHandler.CreateAccessToken(user);

    await _userRepository.AddAsync(user);
    await _userRepository.UpdateRefreshToken(user, token.RefreshToken);

    return new Response<Token>(token);
  }
}