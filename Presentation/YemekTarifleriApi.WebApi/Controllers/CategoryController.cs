using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekTarifleriApi.Application.Features.Commands.Categories.Create;
using YemekTarifleriApi.Application.Features.Commands.Categories.Delete;
using YemekTarifleriApi.Application.Features.Commands.Categories.Update;
using YemekTarifleriApi.Application.Features.Queries.Categories.GetAllCategories;

namespace YemekTarifleriApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
  readonly IMediator _mediator;

  public CategoryController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetAll()
  {
    var response = await _mediator.Send(new GetAllCategoriesQueryRequest());
    return Ok(response);
  }

  [HttpPost]
  [Authorize] //Todo: check admin role
  public async Task<IActionResult> Create(CreateCategoryCommandRequest command)
  {
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpPut]
  [Authorize]
  public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest command)
  {
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommandRequest command)
  {
    var response = await _mediator.Send(command);
    return Ok(response);
  }
}