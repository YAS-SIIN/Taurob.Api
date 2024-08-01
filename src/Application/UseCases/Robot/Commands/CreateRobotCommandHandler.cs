 
using MediatR;

using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Presentation.Shared.Tools;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Mapper;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

/// <summary>
/// Hndler for creating a robot
/// </summary>
public class CreateRobotCommandHandler : IRequestHandler<CreateRobotCommand, ResultDto<RobotResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public CreateRobotCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<RobotResponse>> Handle(CreateRobotCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.NotFound, "The input data is empty.");

        Domain.Entities.Robot inputData = Mapper<Domain.Entities.Robot, CreateRobotCommand>.MappClasses(request);

        await _dbContext.Robots.AddAsync(inputData, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        RobotResponse outputData = Mapper<RobotResponse, Domain.Entities.Robot>.MappClasses(inputData);

        return ResultDto<RobotResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
