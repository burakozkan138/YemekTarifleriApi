using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekTarifleriApi.Application.Features.Commands.Recipes.Create;
using YemekTarifleriApi.Application.Features.Commands.Recipes.Delete;
using YemekTarifleriApi.Application.Features.Commands.Recipes.Update;
using YemekTarifleriApi.Application.Features.Commands.Recipes.Upload;
using YemekTarifleriApi.Application.Features.Queries.Recipes.GetAllRecipes;
using YemekTarifleriApi.Application.Features.Queries.Recipes.GetRecipeDetail;

namespace YemekTarifleriApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
  readonly IMediator _mediator;

  public RecipeController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet("GetAll")]
  public async Task<IActionResult> GetAllRecipes([FromQuery] GetAllRecipesQueryRequest query)
  {
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetRecipeDetail([FromRoute] GetRecipeDetailQueryRequest query)
  {
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> Create([FromBody] CreateRecipeCommandRequest command)
  {
    command.CreatedById = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPost("{id}/[action]")]
  [Authorize]
  public async Task<IActionResult> Upload(string id, IFormFile image)
  {
    var response = await _mediator.Send(new UploadRecipeImageCommandRequest(id, image, new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))));
    return Ok(response);
  }

  [HttpPut]
  [Authorize]
  public async Task<IActionResult> Update([FromBody] UpdateRecipeCommandRequest command)
  {
    command.UserId = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<IActionResult> Delete(string id)
  {
    var response = await _mediator.Send(new DeleteRecipeCommandRequest(id, new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))));
    return Ok(response);
  }
}