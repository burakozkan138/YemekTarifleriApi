using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Update;

public class UpdateUserCommandRequest : IRequest<Response<bool>>
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }
  public string Surname { get; set; }
  public string UserName { get; set; }
  public string Country { get; set; }
}