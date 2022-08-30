using FluentValidation;

namespace YemekTarifleriApi.Application.Features.Commands.Steps.Delete;

public class DeleteStepCommandValidation : AbstractValidator<DeleteStepCommandRequest>
{
  public DeleteStepCommandValidation()
  {
    RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} is not invalid");
  }
}