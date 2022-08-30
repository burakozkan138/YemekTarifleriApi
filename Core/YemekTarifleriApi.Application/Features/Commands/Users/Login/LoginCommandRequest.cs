using MediatR;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Login;

public class LoginCommandRequest : IRequest<Response<Token>>
{
  public string Email { get; set; }
  public string Password { get; set; }
}