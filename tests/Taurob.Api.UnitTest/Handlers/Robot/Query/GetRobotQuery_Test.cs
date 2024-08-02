
using Taurob.Api.Application.Application.UseCases.Robots.Queries;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.Domain.DTOs.Exceptions;
using Taurob.Api.UnitTest;

namespace Mc2.CrudTest.UnitTest.Handlers.Robot.Query;

public class GetRobotQuery_Test
{
    private readonly GetRobotQueryHandler _getRobotQueryHandler;
    public GetRobotQuery_Test()
    {

        TestTools.Initialize();
        _getRobotQueryHandler = new GetRobotQueryHandler(TestTools._dbContext!);

    }

    [Theory]
    [InlineData(1)]
    public async Task GetRobot_ShouldBeSucceeded(int id)
    { 
        var requestData = new GetRobotQuery { Id = id };
        var responseData = await _getRobotQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        TestTools._dbContext?.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task GetRobot_ShouldBeFailed(int id)
    {

        var requestData = new GetRobotQuery { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _getRobotQueryHandler.Handle(requestData, CancellationToken.None));
        TestTools._dbContext?.Dispose();
    }

}
