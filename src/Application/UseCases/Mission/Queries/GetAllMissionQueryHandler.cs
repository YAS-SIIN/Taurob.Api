
using MediatR;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;

using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Application.Application.UseCases.Missions.Queries;

public class GetAllMissionQueryHandler : IRequestHandler<GetAllMissionQuery, ResultDto<IList<MissionResponse>>>
{
    private readonly TaurobDBContext _dbContext;
    public GetAllMissionQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<IList<MissionResponse>>> Handle(GetAllMissionQuery request,
        CancellationToken cancellationToken)
    {

        return ResultDto<IList<MissionResponse>>.ReturnData(null, 0, 0, "");
    }
 
}