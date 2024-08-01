
using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Presentation.Shared.Mapper;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

public class UpdateRobotCommandHandler : IRequestHandler<UpdateRobotCommand, ResultDto<RobotResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public UpdateRobotCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<RobotResponse>> Handle(UpdateRobotCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.NotFound, "The input data is empty.");

        var inputData = await _dbContext.Robots.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == request.Id);

        if (inputData is null && inputData is not Domain.Entities.Robot)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString());
         
        inputData = Mapper<Domain.Entities.Robot, UpdateRobotCommand>.MappClasses(request);

        _dbContext.Robots.Attach(inputData);
        _dbContext.Entry(inputData).State = EntityState.Modified;
       await _dbContext.SaveChangesAsync(cancellationToken);

        RobotResponse outputData = Mapper<RobotResponse, Domain.Entities.Robot>.MappClasses(inputData);

        return ResultDto<RobotResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
