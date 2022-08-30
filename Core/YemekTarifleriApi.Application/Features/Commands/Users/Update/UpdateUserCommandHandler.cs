using AutoMapper;
using MediatR;
using YemekTarifleriApi.Application.Interfaces.Repositories;
using YemekTarifleriApi.Application.Wrappers;

namespace YemekTarifleriApi.Application.Features.Commands.Users.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, Response<bool>>
{
  readonly IUserRepository _userRepository;
  readonly IMapper _mapper;

  public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  public async Task<Response<bool>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
  {
    var dbUser = await _userRepository.GetByIdAsync(request.Id);
    if (dbUser is null)
      throw new Exception("User Not Found");

    _mapper.Map(request, dbUser);
    return new Response<bool>(await _userRepository.Update(dbUser) > 0);
  }
}