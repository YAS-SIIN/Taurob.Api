
using MediatR;

using Microsoft.EntityFrameworkCore;

using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.Application.UseCases.Missions.Queries;

public class GetAllMissionQueryHandler : IRequestHandler<GetAllMissionQuery, ResultDto<IList<MissionResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllMissionQueryHandler(IUnitOfWork uw) => _uw = uw;

    public async Task<ResultDto<IList<MissionResponse>>> Handle(GetAllMissionQuery request,
        CancellationToken cancellationToken)
    {

        return ResultDto<IList<MissionResponse>>.ReturnData(null, 0, 0, "");
    }
 
}