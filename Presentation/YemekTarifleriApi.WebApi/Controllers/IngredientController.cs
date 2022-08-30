using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekTarifleriApi.Application.Features.Commands.Ingredients.Create;
using YemekTarifleriApi.Application.Features.Commands.Ingredients.Delete;
using YemekTarifleriApi.Application.Features.Commands.Ingredients.Update;

namespace YemekTarifleriApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
  readonly IMediator _mediator;

  public IngredientController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> Create([FromBody] CreateIngredientCommandRequest command)
  {
    command.UserId = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPut]
  [Authorize]
  public async Task<IActionResult> Update([FromBody] UpdateIngredientCommandRequest command)
  {
    command.UserId = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<IActionResult> Delete(string id)
  {
    var response = await _mediator.Send(new DeleteIngredientCommandRequest(id, new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))));
    return Ok(response);
  }
}