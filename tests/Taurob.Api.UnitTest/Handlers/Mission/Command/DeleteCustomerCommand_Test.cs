
using FluentValidation;

using Taurob.Api.Application.UseCases.Mission.Commands;
using Taurob.Api.Core.Commands.Mission;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

public class DeleteMissionCommand_Test
{
    private readonly DeleteMissionCommandHandler _deleteMissionCommandHandler;
    public DeleteMissionCommand_Test()
    {

        TestTools.Initialize();
        _deleteMissionCommandHandler = new DeleteMissionCommandHandler(TestTools._dbContext!);

    }

    [Theory]
    [InlineData(1)]
    public async Task DeleteMission_WhenEverythingIsOk_ShouldBeSucceeded(int id)
    { 
        var requestData = new DeleteMissionCommand { Id = id };
        var responseData = await _deleteMissionCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);
        TestTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task DeleteMission_WhenIdNotFound_ShouldBeFailed(int id)
    {

        var requestData = new DeleteMissionCommand { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _deleteMissionCommandHandler.Handle(requestData, CancellationToken.None));
        TestTools._dbContext?.Dispose();
    }
}
