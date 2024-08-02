
using FluentValidation;

using Taurob.Api.Application.Application.UseCases.Robots.Queries;
using Taurob.Api.Core.Queries.Robot;
using Taurob.Api.UnitTest;
namespace Mc2.CrudTest.UnitTest.Handlers.Robot.Query;

public class GetAllRobotQuery_Test
{
    private readonly GetAllRobotQueryHandler _getAllRobotQueryHandler;
    public GetAllRobotQuery_Test()
    {

        TestTools.Initialize();
        _getAllRobotQueryHandler = new GetAllRobotQueryHandler(TestTools._dbContext!);

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
