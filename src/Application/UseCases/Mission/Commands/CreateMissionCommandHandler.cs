
using MediatR;

using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

public class CreateMissionCommandHandler : IRequestHandler<CreateMissionCommand, ResultDto<MissionResponse>>
{
    private readonly IUnitOfWork _uw;
    public CreateMissionCommandHandler(IUnitOfWork uw) => _uw = uw;

    public async Task<ResultDto<MissionResponse>> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
    {
     
        return ResultDto<MissionResponse>.ReturnData(null, 0, 0,"");
    }
}
