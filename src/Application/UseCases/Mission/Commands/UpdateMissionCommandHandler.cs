
using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

public class UpdateMissionCommandHandler : IRequestHandler<UpdateMissionCommand, ResultDto<MissionResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public UpdateMissionCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<MissionResponse>> Handle(UpdateMissionCommand request, CancellationToken cancellationToken)
    {

        return ResultDto<MissionResponse>.ReturnData(null, 0, 0, "");
    }
}
