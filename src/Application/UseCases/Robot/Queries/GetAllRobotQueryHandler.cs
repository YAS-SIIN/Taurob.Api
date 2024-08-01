
using MediatR;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Application.Application.UseCases.Robots.Queries;

public class GetAllRobotQueryHandler : IRequestHandler<GetAllRobotQuery, ResultDto<IList<RobotResponse>>>
{
    private readonly TaurobDBContext _dbContext;
    public GetAllRobotQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<IList<RobotResponse>>> Handle(GetAllRobotQuery request,
        CancellationToken cancellationToken)
    {

        return ResultDto<IList<RobotResponse>>.ReturnData(null, 0, 0, "");
    }
 
}