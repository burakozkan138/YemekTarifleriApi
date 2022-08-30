using MediatR;
using YemekTarifleriApi.Application.Dto;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Register;

public class RegisterCommandRequest : IRequest<Response<Token>>
{
  public string Name { get; set; }
  public string Surname { get; set; }
  public string Email { get; set; }
  public string UserName { get; set; }
  public string Password { get; set; }
  public string ConfirmPassword { get; set; }
}