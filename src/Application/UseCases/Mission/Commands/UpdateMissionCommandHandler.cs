
using MediatR;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Presentation.Shared.Mapper;
using Microsoft.EntityFrameworkCore;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

/// <summary>
/// Hndler for updating a mission
/// </summary>
public class UpdateMissionCommandHandler : IRequestHandler<UpdateMissionCommand, ResultDto<MissionResponse>>
{
    private readonly TaurobDBContext _dbContext;
    public UpdateMissionCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;


    public async Task<ResultDto<MissionResponse>> Handle(UpdateMissionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.NotFound, "The input data is empty.");

        var inputData = await _dbContext.Missions.FindAsync(request.Id, cancellationToken);

        if (inputData is null && inputData is not Domain.Entities.Mission)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString());

         
        _dbContext.Missions.Attach(inputData);
        _dbContext.Entry(inputData).State = EntityState.Modified;
        _dbContext.SaveChanges();

        MissionResponse outputData = Mapper<MissionResponse, Domain.Entities.Mission>.MappClasses(inputData);

        return ResultDto<MissionResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
