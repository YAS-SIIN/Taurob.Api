
using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

public class UpdateRobotCommandHandler : IRequestHandler<UpdateRobotCommand, ResultDto<RobotResponse>>
{
    private readonly IUnitOfWork _uw;
    public UpdateRobotCommandHandler(IUnitOfWork uw) => _uw = uw;


    public async Task<ResultDto<RobotResponse>> Handle(UpdateRobotCommand request, CancellationToken cancellationToken)
    {

        return ResultDto<RobotResponse>.ReturnData(null, 0, 0, "");
    }
}
