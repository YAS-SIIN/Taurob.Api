
using MediatR;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Presentation.Shared.Tools;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Mapper;

namespace Taurob.Api.Application.Application.UseCases.Robots.Queries;

/// <summary>
/// Hndler for get a robot
/// </summary>
public class GetRobotQueryHandler : IRequestHandler<GetRobotQuery, ResultDto<RobotResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public GetRobotQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<RobotResponse>> Handle(GetRobotQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _dbContext.Robots.FindAsync(request.Id, cancellationToken);

        if (response is not Domain.Entities.Robot)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString());

        RobotResponse resData = Mapper<RobotResponse, Domain.Entities.Robot>.MappClasses(response);


        return ResultDto<RobotResponse>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
 
}