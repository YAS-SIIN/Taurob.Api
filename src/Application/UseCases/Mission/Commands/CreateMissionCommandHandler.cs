
using MediatR;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.DTOs.Mission;
using Taurob.Api.Domain.Enums;
using Taurob.Api.Infra.Data.Context;
using Taurob.Api.Presentation.Shared.Mapper;
using Taurob.Api.Presentation.Shared.Tools;

namespace Taurob.Api.Application.UseCases.Mission.Commands;

/// <summary>
/// Hndler for creating a mission
/// </summary>
public class CreateMissionCommandHandler : IRequestHandler<CreateMissionCommand, ResultDto<MissionResponse>>
{

    private readonly TaurobDBContext _dbContext;
    public CreateMissionCommandHandler(TaurobDBContext dbContext) => _dbContext = dbContext;

    public async Task<ResultDto<MissionResponse>> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.NotFound, "The input data is empty.");

        Domain.Entities.Mission inputData = Mapper<Domain.Entities.Mission, CreateMissionCommand>.MappClasses(request);

        await _dbContext.Missions.AddAsync(inputData, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        MissionResponse outputData = Mapper<MissionResponse, Domain.Entities.Mission>.MappClasses(inputData);

        return ResultDto<MissionResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
