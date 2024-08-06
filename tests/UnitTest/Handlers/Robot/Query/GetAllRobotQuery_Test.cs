
using FluentValidation;

using Taurob.Api.Application.Application.UseCases.Robots.Queries;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.UnitTest;
using Taurob.Api.UnitTest.Handlers.Mission.Query;
namespace Taurob.Api.UnitTest.Handlers.Robot.Query;

public class GetAllRobotQuery_Test
{
    private readonly GetAllRobotQueryHandler _getAllRobotQueryHandler;
    private readonly TestTools _testTools;
    public GetAllRobotQuery_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(GetAllRobotQuery_Test));
        _getAllRobotQueryHandler = new GetAllRobotQueryHandler(_testTools._dbContext!);

    }

    [Fact]
    public async Task GetAllRobot_ShouldBeSucceeded()
    { 
        var requestData = new GetAllRobotQuery();
        var responseData = await _getAllRobotQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        Assert.NotEqual(0, responseData.Data.Count);
    }
     
}
