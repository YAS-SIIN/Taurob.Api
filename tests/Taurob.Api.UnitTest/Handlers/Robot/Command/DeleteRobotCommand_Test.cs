
using FluentValidation;

using Taurob.Api.Application.UseCases.Robot.Commands;
using Taurob.Api.Core.Commands.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.Domain.Enums;

namespace Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;

public class DeleteRobotCommand_Test
{
    private readonly DeleteRobotCommandHandler _deleteRobotCommandHandler;
    public DeleteRobotCommand_Test()
    {

        TestTools.Initialize();
        _deleteRobotCommandHandler = new DeleteRobotCommandHandler(TestTools._dbContext!);

    }

    [Theory]
    [InlineData(1)]
    public async Task DeleteRobot_WhenEverythingIsOk_ShouldBeSucceeded(int id)
    { 
        var requestData = new DeleteRobotCommand { Id = id };
        var responseData = await _deleteRobotCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);

        var deletedRow = await TestTools._dbContext.Robots.FindAsync(id);

        Assert.Null(deletedRow);

        TestTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task DeleteRobot_WhenIdNotFound_ShouldBeFailed(int id)
    {

        var requestData = new DeleteRobotCommand { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _deleteRobotCommandHandler.Handle(requestData, CancellationToken.None));
        TestTools._dbContext?.Dispose();
    }
}
