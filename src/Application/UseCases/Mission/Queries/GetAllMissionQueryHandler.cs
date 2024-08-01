
using MediatR;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.Application.UseCases.Missions.Queries;

/// <summary>
/// Hndler for get list of mission
/// </summary>
public class GetAllMissionQueryHandler : IRequestHandler<GetAllMissionQuery, ResultDto<IList<MissionResponse>>>
{
    private readonly TaurobDBContext _dbContext;
    public GetAllMissionQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<IList<MissionResponse>>> Handle(GetAllMissionQuery request,
        CancellationToken cancellationToken)
    {
        var resData = _dbContext.Missions.Select(x => new MissionResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            RobotId = x.RobotId,
        }).ToList();

        return ResultDto<IList<MissionResponse>>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
 
}