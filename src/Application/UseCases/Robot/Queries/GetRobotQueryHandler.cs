
using MediatR;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Application.Application.UseCases.Robots.Queries;

public class GetRobotQueryHandler : IRequestHandler<GetRobotQuery, ResultDto<RobotResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public GetRobotQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<RobotResponse>> Handle(GetRobotQuery request,
        CancellationToken cancellationToken)
    {


        return ResultDto<RobotResponse>.ReturnData(null, 0, 0, "");
    }
 
}