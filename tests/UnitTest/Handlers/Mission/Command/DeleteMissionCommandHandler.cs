
using FluentValidation;

using Taurob.Api.Application.UseCases.Mission.Commands;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;
using Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

public class DeleteMissionCommand_Test
{
    private readonly DeleteMissionCommandHandler _deleteMissionCommandHandler;
    private readonly TestTools _testTools;
    public DeleteMissionCommand_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(DeleteMissionCommand_Test));
        _deleteMissionCommandHandler = new DeleteMissionCommandHandler(_testTools._dbContext!);

    }

    [Theory]
    [InlineData(3)]
    public async Task DeleteMission_WhenEverythingIsOk_ShouldBeSucceeded(int id)
    { 
        var requestData = new DeleteMissionCommand { Id = id };
        var responseData = await _deleteMissionCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);

        var deletedRow = await _testTools._dbContext.Missions.FindAsync(id);

        Assert.Null(deletedRow);

        _testTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task DeleteMission_WhenIdNotFound_ShouldBeFailed(int id)
    {

        var requestData = new DeleteMissionCommand { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _deleteMissionCommandHandler.Handle(requestData, CancellationToken.None));
        _testTools._dbContext?.Dispose();
    }
}
