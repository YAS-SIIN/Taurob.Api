
using MediatR;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.Application.UseCases.Robots.Queries;

public class GetAllRobotQueryHandler : IRequestHandler<GetAllRobotQuery, ResultDto<IList<RobotResponse>>>
{
    private readonly TaurobDBContext _dbContext;
    public GetAllRobotQueryHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<IList<RobotResponse>>> Handle(GetAllRobotQuery request,
        CancellationToken cancellationToken)
    {
        var response = _dbContext.Robots;
        var resData = response.Select(x => new RobotResponse
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Modelname = x.Modelname
        }).ToList();

        return ResultDto<IList<RobotResponse>>.ReturnData(resData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
 
}