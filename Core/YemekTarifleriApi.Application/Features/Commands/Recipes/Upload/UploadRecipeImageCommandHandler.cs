using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Recipes.Upload;

public class UploadRecipeImageCommandHandler : IRequestHandler<UploadRecipeImageCommandRequest, Response<string>>
{
  readonly IRecipeRepository _recipeRepository;
  readonly IWebHostEnvironment _webHostEnvironment;

  public UploadRecipeImageCommandHandler(IWebHostEnvironment webHostEnvironment, IRecipeRepository recipeRepository)
  {
    _webHostEnvironment = webHostEnvironment;
    _recipeRepository = recipeRepository;
  }

  public async Task<Response<string>> Handle(UploadRecipeImageCommandRequest request, CancellationToken cancellationToken)
  {
    var recipe = await _recipeRepository.GetByIdAsync(request.Id);
    if (recipe is null)
      throw new Exception("recipe not found");
    if (recipe.CreatedById != request.UserId)
      throw new Exception("You are not allowed to upload image for this recipe");

    recipe.Image = await UploadImage(request.File, recipe.Id.ToString());

    await _recipeRepository.Update(recipe);
    return new Response<string>(recipe.Image);
  }

  async Task<string> UploadImage(IFormFile image, string imageName)
  {
    if (image == null)
      throw new Exception("image not found");
    if (!image.ContentType.Contains("image"))
      throw new Exception("image type not sported");

    imageName = $"{imageName}{Path.GetExtension(image.FileName)}";
    var imagePath = $"images/{imageName}";
    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

    try
    {
      await using FileStream fileStream = new(uploadPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

      await image.CopyToAsync(fileStream);
      await fileStream.FlushAsync();
    }
    catch (Exception)
    {
      throw new Exception("Image not uploaded");
    }

    return imageName;
  }
}