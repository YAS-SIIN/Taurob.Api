 
using MediatR;

using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Robot;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.UseCases.Robot.Commands;

public class CreateRobotCommandHandler : IRequestHandler<CreateRobotCommand, ResultDto<RobotResponse>>
{
    private readonly IUnitOfWork _uw;
    public CreateRobotCommandHandler(IUnitOfWork uw) => _uw = uw;

    public async Task<ResultDto<RobotResponse>> Handle(CreateRobotCommand request, CancellationToken cancellationToken)
    {
     
        return ResultDto<RobotResponse>.ReturnData(null, 0, 0,"");
    }
}
