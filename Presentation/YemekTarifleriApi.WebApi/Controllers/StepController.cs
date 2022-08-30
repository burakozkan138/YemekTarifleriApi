using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekTarifleriApi.Application.Features.Commands.Steps.Create;
using YemekTarifleriApi.Application.Features.Commands.Steps.Delete;
using YemekTarifleriApi.Application.Features.Commands.Steps.Update;

namespace YemekTarifleriApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StepController : ControllerBase
{
  readonly IMediator _mediator;

  public StepController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> Create([FromBody] CreateStepCommandRequest command)
  {
    command.UserId = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPut]
  [Authorize]
  public async Task<IActionResult> Update([FromBody] UpdateStepCommandRequest command)
  {
    command.UserId = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<IActionResult> Delete(string id)
  {
    var response = await _mediator.Send(new DeleteStepCommandRequest(id, new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))));
    return Ok(response);
  }
}