using MediatR;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.RefreshTokenLogin;

public class RefreshTokenLoginCommandRequest : IRequest<Response<Token>>
{
  public string RefreshToken { get; set; }
}