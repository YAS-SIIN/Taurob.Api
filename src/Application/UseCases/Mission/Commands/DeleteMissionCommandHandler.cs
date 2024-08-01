
using MediatR;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

/// <summary>
/// Hndler for deleting a mission
/// </summary>
public class DeleteMissionCommandHandler : IRequestHandler<DeleteMissionCommand, ResultDto<int>>
{
    private readonly TaurobDBContext _dbContext;
    public DeleteMissionCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<int>> Handle(DeleteMissionCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _dbContext.Missions.FindAsync(request.Id, cancellationToken);

        if (inputData is not Domain.Entities.Mission)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString());

        _dbContext.Missions.Remove(inputData);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ResultDto<int>.ReturnData(request.Id, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
