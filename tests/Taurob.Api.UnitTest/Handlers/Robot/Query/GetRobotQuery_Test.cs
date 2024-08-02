
using Taurob.Api.Application.Application.UseCases.Robots.Queries;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.UnitTest;
using Taurob.Api.UnitTest.Handlers.Mission.Query;

namespace Taurob.Api.UnitTest.Handlers.Robot.Query;

public class GetRobotQuery_Test
{
    private readonly GetRobotQueryHandler _getRobotQueryHandler;
    private readonly TestTools _testTools;
    public GetRobotQuery_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(GetRobotQuery_Test));
        _getRobotQueryHandler = new GetRobotQueryHandler(_testTools._dbContext!);

    }

    [Theory]
    [InlineData(4)]
    public async Task GetRobot_ShouldBeSucceeded(int id)
    { 
        var requestData = new GetRobotQuery { Id = id };
        var responseData = await _getRobotQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        _testTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task GetRobot_ShouldBeFailed(int id)
    {

        var requestData = new GetRobotQuery { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _getRobotQueryHandler.Handle(requestData, CancellationToken.None));
        _testTools._dbContext?.Dispose();
    }

}
