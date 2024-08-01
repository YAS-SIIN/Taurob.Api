
using MediatR;

using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

public class DeleteRobotCommandHandler : IRequestHandler<DeleteRobotCommand, ResultDto<int>>
{
    private readonly IUnitOfWork _uw;
    public DeleteRobotCommandHandler(IUnitOfWork uw) => _uw = uw;

    public async Task<ResultDto<int>> Handle(DeleteRobotCommand request, CancellationToken cancellationToken)
    { 
        return ResultDto<int>.ReturnData(0, 0, 0, "");
    }
}
