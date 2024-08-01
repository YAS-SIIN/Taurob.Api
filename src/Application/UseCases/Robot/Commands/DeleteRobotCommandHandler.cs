
using MediatR;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Infra.Data.Context;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

public class DeleteRobotCommandHandler : IRequestHandler<DeleteRobotCommand, ResultDto<int>>
{
    private readonly TaurobDBContext _dbContext;
    public DeleteRobotCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<int>> Handle(DeleteRobotCommand request, CancellationToken cancellationToken)
    { 
        return ResultDto<int>.ReturnData(0, 0, 0, "");
    }
}
