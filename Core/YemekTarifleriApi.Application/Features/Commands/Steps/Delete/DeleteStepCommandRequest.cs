using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Delete;

public class DeleteStepCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public Guid UserId { get; set; }

  public DeleteStepCommandRequest(string id, Guid userId)
  {
    Id = id;
    UserId = userId;
  }
}