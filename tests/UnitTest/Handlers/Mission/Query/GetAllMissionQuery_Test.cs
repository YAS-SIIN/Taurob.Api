
using FluentValidation;

using Taurob.Api.Application.Application.UseCases.Missions.Queries;
using Taurob.Api.Core.Queries.Mission;
using Taurob.Api.UnitTest.UnitTest.Handlers.Robot.Command;
namespace Taurob.Api.UnitTest.Handlers.Mission.Query;

public class GetAllMissionQuery_Test
{
    private readonly GetAllMissionQueryHandler _getAllMissionQueryHandler;
    private readonly TestTools _testTools;
    public GetAllMissionQuery_Test()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(GetAllMissionQuery_Test));
        _getAllMissionQueryHandler = new GetAllMissionQueryHandler(_testTools._dbContext!);

    }

    [Fact]
    public async Task GetAllMission_ShouldBeSucceeded()
    { 
        var requestData = new GetAllMissionQuery();
        var responseData = await _getAllMissionQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        Assert.NotEqual(0, responseData.Data.Count);
    }
     
}
