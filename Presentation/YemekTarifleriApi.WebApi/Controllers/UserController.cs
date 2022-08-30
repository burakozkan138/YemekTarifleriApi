using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekTarifleriApi.Application.Features.Commands.Users.Login;
using YemekTarifleriApi.Application.Features.Commands.Users.RefreshTokenLogin;
using YemekTarifleriApi.Application.Features.Commands.Users.Register;
using YemekTarifleriApi.Application.Features.Commands.Users.Update;

namespace YemekTarifleriApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
  readonly IMediator _mediator;

  public UserController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> Register([FromBody] RegisterCommandRequest command)
  {
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> Login([FromBody] LoginCommandRequest command)
  {
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest command)
  {
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPut]
  [Authorize]
  public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest command)
  {
    command.Id = new Guid(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    var response = await _mediator.Send(command);
    return Ok(response);
  }
}