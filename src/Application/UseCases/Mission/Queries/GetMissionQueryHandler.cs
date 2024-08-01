
using MediatR;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Mapper;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.Application.UseCases.Missions.Queries;

/// <summary>
/// Hndler for get a mission
/// </summary>
public class GetMissionQueryHandler : IRequestHandler<GetMissionQuery, ResultDto<MissionResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public GetMissionQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<MissionResponse>> Handle(GetMissionQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _dbContext.Missions.FindAsync(request.Id, cancellationToken);

        if (response is not Domain.Entities.Mission)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString());

        MissionResponse resData = Mapper<MissionResponse, Domain.Entities.Mission>.MappClasses(response);


        return ResultDto<MissionResponse>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
 
}