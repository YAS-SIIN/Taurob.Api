
using MediatR;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

public class DeleteRobotCommandHandler : IRequestHandler<DeleteRobotCommand, ResultDto<int>>
{
    private readonly TaurobDBContext _dbContext;
    public DeleteRobotCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<int>> Handle(DeleteRobotCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _dbContext.Robots.FindAsync(request.Id, cancellationToken);

        if (inputData is not Domain.Entities.Robot)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString());

        _dbContext.Robots.Remove(inputData);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ResultDto<int>.ReturnData(request.Id, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
