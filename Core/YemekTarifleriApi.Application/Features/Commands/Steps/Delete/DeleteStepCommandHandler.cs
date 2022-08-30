using MediatR;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Delete;

public class DeleteStepCommandHandler : IRequestHandler<DeleteStepCommandRequest, Response<bool>>
{
  readonly IStepRepository _stepRepository;

  public DeleteStepCommandHandler(IStepRepository stepRepository)
  {
    _stepRepository = stepRepository;
  }

  public async Task<Response<bool>> Handle(DeleteStepCommandRequest request, CancellationToken cancellationToken)
  {
    var step = await _stepRepository.GetWhere(i => i.Id.ToString() == request.Id)
      .Include(x => x.Recipe)
      .FirstOrDefaultAsync(cancellationToken);

    if (step == null)
      throw new Exception("Step not found");
    if (step.Recipe.CreatedById != request.UserId)
      throw new Exception("You are not authorized to delete this step");

    return new Response<bool>(await _stepRepository.Remove(step) > 0);
  }
}