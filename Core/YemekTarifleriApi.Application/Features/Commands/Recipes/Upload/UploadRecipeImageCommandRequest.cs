using MediatR;
using Microsoft.AspNetCore.Http;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Upload;

public class UploadRecipeImageCommandRequest : IRequest<Response<string>>
{
  public string Id { get; set; }
  public IFormFile File { get; set; }
  public Guid UserId { get; set; }

  public UploadRecipeImageCommandRequest(string id, IFormFile file, Guid userId)
  {
    Id = id;
    File = file;
    UserId = userId;
  }
}