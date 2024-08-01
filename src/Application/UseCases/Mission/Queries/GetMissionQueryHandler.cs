
using MediatR;

using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.Application.UseCases.Missions.Queries;

public class GetMissionQueryHandler : IRequestHandler<GetMissionQuery, ResultDto<MissionResponse>>
{

    private readonly IUnitOfWork _uw;
    public GetMissionQueryHandler(IUnitOfWork uw) => _uw = uw;
    

    public async Task<ResultDto<MissionResponse>> Handle(GetMissionQuery request,
        CancellationToken cancellationToken)
    {


        return ResultDto<MissionResponse>.ReturnData(null, 0, 0, "");
    }
 
}