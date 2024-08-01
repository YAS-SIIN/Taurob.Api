
using MediatR;

using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.Application.UseCases.Robots.Queries;

public class GetRobotQueryHandler : IRequestHandler<GetRobotQuery, ResultDto<RobotResponse>>
{

    private readonly IUnitOfWork _uw;
    public GetRobotQueryHandler(IUnitOfWork uw) => _uw = uw;
    

    public async Task<ResultDto<RobotResponse>> Handle(GetRobotQuery request,
        CancellationToken cancellationToken)
    {


        return ResultDto<RobotResponse>.ReturnData(null, 0, 0, "");
    }
 
}