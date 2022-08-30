using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Update;

public class UpdateStepCommandHandler : IRequestHandler<UpdateStepCommandRequest, Response<bool>>
{
  readonly IStepRepository _stepRepository;
  readonly IMapper _mapper;

  public UpdateStepCommandHandler(IStepRepository stepRepository, IMapper mapper)
  {
    _stepRepository = stepRepository;
    _mapper = mapper;
  }

  public async Task<Response<bool>> Handle(UpdateStepCommandRequest request, CancellationToken cancellationToken)
  {
    var step = await _stepRepository.GetWhere(i => i.Id.ToString() == request.Id)
      .Include(x => x.Recipe)
      .FirstOrDefaultAsync(cancellationToken);

    if (step == null)
      throw new Exception("Step not found");
    if (step.Recipe.CreatedById != request.UserId)
      throw new Exception("You are not authorized to update this step");

    _mapper.Map(request, step);
    return new Response<bool>(await _stepRepository.Update(step) > 0);
  }
}