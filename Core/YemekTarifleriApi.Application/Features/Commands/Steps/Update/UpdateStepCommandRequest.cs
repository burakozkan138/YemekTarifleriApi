using System.Text.Json.Serialization;
using MediatR;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Update;

public class UpdateStepCommandRequest : IRequest<Response<bool>>
{
  public string Id { get; set; }
  public int Number { get; set; }
  public string Description { get; set; }
  [JsonIgnore] public Guid UserId { get; set; }
}