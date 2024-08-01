
using MediatR;

using Microsoft.EntityFrameworkCore;

using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.Application.UseCases.Robots.Queries;

public class GetAllRobotQueryHandler : IRequestHandler<GetAllRobotQuery, ResultDto<IList<RobotResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllRobotQueryHandler(IUnitOfWork uw) => _uw = uw;

    public async Task<ResultDto<IList<RobotResponse>>> Handle(GetAllRobotQuery request,
        CancellationToken cancellationToken)
    {

        return ResultDto<IList<RobotResponse>>.ReturnData(null, 0, 0, "");
    }
 
}