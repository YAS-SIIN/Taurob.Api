
using MediatR;

using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Interfaces.UnitOfWork;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

public class DeleteMissionCommandHandler : IRequestHandler<DeleteMissionCommand, ResultDto<int>>
{
    private readonly IUnitOfWork _uw;
    public DeleteMissionCommandHandler(IUnitOfWork uw) => _uw = uw;

    public async Task<ResultDto<int>> Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
    { 
        return ResultDto<int>.ReturnData(0, 0, 0, "");
    }
}
