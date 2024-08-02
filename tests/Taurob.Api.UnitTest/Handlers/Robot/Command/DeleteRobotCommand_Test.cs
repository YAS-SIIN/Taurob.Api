
using FluentValidation;

using Taurob.Api.Application.UseCases.Robot.Commands;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;
using Taurob.Api.UnitTest.UnitTest.Handlers.Mission.Command;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

public class DeleteRobotCommand_Test
{
    private readonly DeleteRobotCommandHandler _deleteRobotCommandHandler;
    private readonly TestTools _testTools;
    public DeleteRobotCommand_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(DeleteRobotCommand_Test));
        _deleteRobotCommandHandler = new DeleteRobotCommandHandler(_testTools._dbContext!);

    }

    [Theory]
    [InlineData(3)]
    public async Task DeleteRobot_WhenEverythingIsOk_ShouldBeSucceeded(int id)
    { 
        var requestData = new DeleteRobotCommand { Id = id };
        var responseData = await _deleteRobotCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);

        var deletedRow = await _testTools._dbContext.Robots.FindAsync(id);

        Assert.Null(deletedRow);

        _testTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task DeleteRobot_WhenIdNotFound_ShouldBeFailed(int id)
    {

        var requestData = new DeleteRobotCommand { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _deleteRobotCommandHandler.Handle(requestData, CancellationToken.None));
        _testTools._dbContext?.Dispose();
    }
}
